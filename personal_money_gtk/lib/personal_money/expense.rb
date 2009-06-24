class Expense
  def initialize(data_layer, row = nil)
    @data_layer = data_layer
    if row
      @expense_id = row['id']
      @expense_date = row['expense_date']
      @amount = row['amount']
      @payment_form_id = row['payment_form_id']
      @expense_type_id = row['expense_type_id']
      @description = row['description']
      @accounting_month = row['accounting_month']
      @number_accounting_month = row['number_accounting_month']
    else
      @expense_id = nil
      @expense_date = Date.today
      @amount = 0
      @payment_form_id = nil
      @expense_type_id = nil
      @description = ''
      @accounting_month = Date.new(Date.today.year, Date.today.month, 1)
      @number_accounting_month = 1
    end
  end

  attr_reader :expense_id
  attr_accessor :amopunt, :expense_date, :amount, :description, :accounting_month, :number_accounting_month

  def payment_form
    @data_layer.get_payment_form_by_id(@payment_form_id)
  end
  
  def payment_form=(payment_form)
    @payment_form_id = payment_form.payment_form_id
  end

  def expense_type
    @data_layer.get_expense_type_by_id(@expense_type_id)
  end
  
  def expense_type=(expense_type)
    @expense_type_id = expense_type.expense_type_id
  end
  
  def save(data_layer)
    if @expense_id
      data_layer.update_expense(@expense_id, @expense_date, @amount, @payment_form_id, @expense_type_id, @description, @accounting_month, @number_accounting_month)
    else
      @expense_id = data_layer.insert_expense(@expense_date, @amount, @payment_form_id, @expense_type_id, @description, @accounting_month, @number_accounting_month)
    end
  end
  
  def to_s
    if @expense_id
      "Expense ##{@expense_id.to_s}"
    else
      "New Expense"
    end
  end
end
