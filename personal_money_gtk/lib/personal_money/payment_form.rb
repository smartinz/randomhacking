class PaymentForm
  def initialize(row)
    @payment_form_id = row[0]
    @description = row[1]
  end

  attr_reader :payment_form_id
  
  attr_accessor :description
end