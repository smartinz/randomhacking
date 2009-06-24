class DataLayer
  def initialize(file_name)
    @file_name = file_name
    new_file = !File.exists?(@file_name)
    @database = SQLite3::Database.new(@file_name, :type_translation => true, :results_as_hash => true)
    create_schema if new_file
    @database.translator.add_translator('date') { |type, value| Date.parse(value, true) }
    @expense_types = nil
    @payment_forms = nil
  end

  def to_s
    File.basename(@file_name)
  end

  def get_expenses
    rows = @database.execute <<-SQL
    	SELECT
      expenses.id,
      expenses.expense_date,
      expenses.amount,
      expenses.payment_form_id,
      expenses.expense_type_id,
      expenses.description,
      expenses.accounting_month,
      expenses.number_accounting_month
      FROM expenses
    SQL
    expenses = []
    rows.each do |row|
      row['amount'] = row[2] = row[2] / 100.0 
      expenses << Expense.new(self, row)
    end
    expenses
  end

  def insert_expense(expense_date, amount, payment_form_id, expense_type_id, description, accounting_month, number_accounting_month)
    amount, accounting_month = check_expense(amount, payment_form_id, expense_type_id, accounting_month)
    begin
      @database.execute <<-SQL
        INSERT INTO expenses(expense_date, amount, payment_form_id, expense_type_id, description, accounting_month, number_accounting_month)
        VALUES(#{date_to_sql(expense_date)}, 
        #{numeric_to_sql(amount)}, 
        #{numeric_to_sql(payment_form_id)}, 
        #{numeric_to_sql(expense_type_id)}, 
        #{string_to_sql(description)}, 
        #{date_to_sql(accounting_month)}, 
        #{numeric_to_sql(number_accounting_month)})
      SQL
      @database.last_insert_row_id
    rescue SQLite3::SQLException => exception
      raise "Error executing INSERT statement: #{exception.message}"
    end
  end

  def update_expense(expense_id, expense_date, amount, payment_form_id, expense_type_id, description, accounting_month, number_accounting_month)
    amount, accounting_month = check_expense(amount, payment_form_id, expense_type_id, accounting_month)
    begin
      @database.execute <<-SQL
        UPDATE expenses SET
        expense_date = #{date_to_sql(expense_date)}, 
        amount = #{numeric_to_sql(amount)},
        payment_form_id = #{numeric_to_sql(payment_form_id)},
        expense_type_id = #{numeric_to_sql(expense_type_id)},
        description = #{string_to_sql(description)},
        accounting_month = #{date_to_sql(accounting_month)},
        number_accounting_month = #{numeric_to_sql(number_accounting_month)}
        WHERE id = #{numeric_to_sql(expense_id)}
      SQL
    rescue SQLite3::SQLException => exception
      raise "Error executing UPDATE statement: #{exception.message}"
    end
  end

  def delete_expense(expense_id)
    begin
      @database.execute <<-SQL
        DELETE FROM expenses WHERE id = #{numeric_to_sql(expense_id)}
      SQL
    rescue SQLite3::SQLException => exception
      raise "Error executing DELETE statement: #{exception.message}"
    end
  end
  
  def check_presence_of_payment_form(payment_form_id)
    rows = @database.execute("SELECT * FROM payment_forms WHERE id = #{numeric_to_sql(payment_form_id)}")
    raise "#{payment_form_id} not found in payment_forms.id" if rows.length == 0
  end
  
  def check_presence_of_expense_types(expense_type_id)
    rows = @database.execute("SELECT * FROM expense_types WHERE id = #{numeric_to_sql(expense_type_id)}")
    raise "#{expense_type_id} not found in expense_types.id" if rows.length == 0
  end

  def lazy_load_payment_forms
    if @payment_forms == nil
      rows = @database.execute <<-SQL
      	SELECT
        payment_forms.id,
        payment_forms.description
        FROM payment_forms
      SQL
      @payment_forms = Hash.new
      rows.each do |row|
        @payment_forms[row[0]] = PaymentForm.new(row)
      end
    end
  end

  def get_payment_forms
    lazy_load_payment_forms
    @payment_forms.values
  end

  def get_payment_form_by_id(id)
    lazy_load_payment_forms
    @payment_forms[id]
  end
  
  def lazy_load_expense_types
    if @expense_types == nil
      rows = @database.execute <<-SQL
        SELECT
        expense_types.id,
        expense_types.description
        FROM expense_types
      SQL
      @expense_types = Hash.new
      rows.each do |row|
        @expense_types[row[0]] = ExpenseType.new(row)
      end
    end
  end
 
  def get_expense_types
    lazy_load_expense_types
    @expense_types.values
  end
  
  def get_expense_type_by_id(id)
    lazy_load_expense_types
    @expense_types[id]
  end
  
private

  def create_schema
    @database.execute <<-SQL
      CREATE TABLE expense_types ("id" INTEGER PRIMARY KEY NOT NULL, "description" varchar(100) NOT NULL);
    SQL
    @database.execute <<-SQL
      CREATE TABLE expenses ("id" INTEGER PRIMARY KEY NOT NULL, "expense_date" date NOT NULL, "amount" integer NOT NULL, "payment_form_id" integer NOT NULL, "expense_type_id" integer NOT NULL, "description" varchar(100) NOT NULL, "accounting_month" date NOT NULL, "number_accounting_month" integer NOT NULL);
    SQL
    @database.execute <<-SQL
      CREATE TABLE payment_forms ("id" INTEGER PRIMARY KEY NOT NULL, "description" varchar(100) NOT NULL);
    SQL
    @database.execute <<-SQL
      CREATE TABLE schema_info (version integer);
    SQL
  end
  
  def check_expense(amount, payment_form_id, expense_type_id, accounting_month)
    check_presence_of_payment_form(payment_form_id)
    check_presence_of_expense_types(expense_type_id)
    accounting_month = Date.new(accounting_month.year, accounting_month.month, 1)
    amount = (amount * 100.0).truncate
    return amount, accounting_month
  end

  def date_to_sql(date)
    if date
      '\'' + date.strftime('%F') + '\''
    else
      'NULL'
    end
  end
  
  def numeric_to_sql(number)
    if number
      number.to_s
    else
      'NULL'
    end
  end

  def string_to_sql(str)
    if str != nil and str.length > 0
      '\'' + str + '\''
    else
      'NULL'
    end
  end
end
