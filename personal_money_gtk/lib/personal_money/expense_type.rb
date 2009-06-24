class ExpenseType
  def initialize(row)
    @expense_type_id = row[0]
    @description = row[1]
  end
  
  def eql?(other)
    if (other.class == self.class) && (@expense_type_id == other.expense_type_id)
      true
    else
      false
    end
  end
  
  def hash
    @expense_type_id
  end

  attr_reader :expense_type_id
  
  attr_accessor :description
end