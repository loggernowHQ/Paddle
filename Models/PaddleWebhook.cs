using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Loggernow.Paddle.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Loggernow.Paddle.Models
{
    // Paddle is a PHP application, and passes all of its POST params as strings
    // We need to make sure MVC does not convert an empty string to NULL
    public class PaddleWebhook
    {
        #region class fields
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? alert_id { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? custom_data { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? ip { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? product_id { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? attempt_number { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? used_price_override { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? alert_name { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? subscription_id { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? status { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? email { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? marketing_consent { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? subscription_plan_id { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? next_bill_date { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? update_url { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? cancel_url { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? currency { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? checkout_id { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? passthrough { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? new_quantity { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? old_quantity { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? new_unit_price { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? old_unit_price { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? new_price { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? old_price { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? cancellation_effective_date { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? user_id { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? order_id { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? country { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? sale_gross { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? fee { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? earnings { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? customer_name { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? plan_name { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? payment_tax { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? payment_method { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? balance_currency { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? balance_tax { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? balance_earnings { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? balance_fee { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? balance_gross { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? coupon { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? initial_payment { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? receipt_url { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? instalments { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? quantity { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? unit_price { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? next_retry_date { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? amount { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? event_time { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? subscription_payment_id { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? p_signature { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? gross_refund { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? tax_refund { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? fee_refund { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? earnings_decrease { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? balance_gross_refund { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? balance_tax_refund { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? balance_fee_refund { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? balance_earnings_decrease { get; set; }
        #endregion

        /// <summary>
        /// This Takes in Http request and initialises all paddle webhook model  fileds present in http request
        /// </summary>
        /// <param name="req"></param>
        internal PaddleWebhook(HttpRequest req,[Optional] LgLogger logger)
        {
            var formItemList = req.Form.ToList();
            var type = this.GetType();
            var properties = type.GetProperties();
            foreach (var formItem in formItemList)
            {
                bool formValueSet = false;
                foreach (var property in properties)
                {
                    string propertyName=property.Name;
                    string formValue = formItem.Value;
                    string formKey = formItem.Key;
                    if (propertyName == formKey && property.CanWrite)
                    {
                        property.SetValue(this, formValue, null);
                        formValueSet = true;
                    }
                    else if(property.Name == formKey && !property.CanWrite)
                    {
                        logger.LogError("Error - Unable to set propert present in paddle webhook.Please contact Author or check github repository.");
                        throw new Exception("Unable to set propert present in paddle webhook.Please contact Author or check github repository.");
                    }
                }
                if (formValueSet == false)
                {
                    logger.LogCritical("Paddle Webhook structure has changed the field "+formItem.Key+" is not present in class variables.Create issue on github.");
                }
            }
        }

        public PaddleWebhook(string? alert_id, string? custom_data, string? ip, string? product_id, string? attempt_number, string? used_price_override, string? alert_name, string? subscription_id, string? status, string? email, string? marketing_consent, string? subscription_plan_id, string? next_bill_date, string? update_url, string? cancel_url, string? currency, string? checkout_id, string? passthrough, string? new_quantity, string? old_quantity, string? new_unit_price, string? old_unit_price, string? new_price, string? old_price, string? cancellation_effective_date, string? user_id, string? order_id, string? country, string? sale_gross, string? fee, string? earnings, string? customer_name, string? plan_name, string? payment_tax, string? payment_method, string? balance_currency, string? balance_tax, string? balance_earnings, string? balance_fee, string? balance_gross, string? coupon, string? initial_payment, string? receipt_url, string? instalments, string? quantity, string? unit_price, string? next_retry_date, string? amount, string? event_time, string? subscription_payment_id, string? p_signature, string? gross_refund, string? tax_refund, string? fee_refund, string? earnings_decrease, string? balance_gross_refund, string? balance_tax_refund, string? balance_fee_refund, string? balance_earnings_decrease)
        {
            this.alert_id = alert_id;
            this.custom_data = custom_data;
            this.ip = ip;
            this.product_id = product_id;
            this.attempt_number = attempt_number;
            this.used_price_override = used_price_override;
            this.alert_name = alert_name;
            this.subscription_id = subscription_id;
            this.status = status;
            this.email = email;
            this.marketing_consent = marketing_consent;
            this.subscription_plan_id = subscription_plan_id;
            this.next_bill_date = next_bill_date;
            this.update_url = update_url;
            this.cancel_url = cancel_url;
            this.currency = currency;
            this.checkout_id = checkout_id;
            this.passthrough = passthrough;
            this.new_quantity = new_quantity;
            this.old_quantity = old_quantity;
            this.new_unit_price = new_unit_price;
            this.old_unit_price = old_unit_price;
            this.new_price = new_price;
            this.old_price = old_price;
            this.cancellation_effective_date = cancellation_effective_date;
            this.user_id = user_id;
            this.order_id = order_id;
            this.country = country;
            this.sale_gross = sale_gross;
            this.fee = fee;
            this.earnings = earnings;
            this.customer_name = customer_name;
            this.plan_name = plan_name;
            this.payment_tax = payment_tax;
            this.payment_method = payment_method;
            this.balance_currency = balance_currency;
            this.balance_tax = balance_tax;
            this.balance_earnings = balance_earnings;
            this.balance_fee = balance_fee;
            this.balance_gross = balance_gross;
            this.coupon = coupon;
            this.initial_payment = initial_payment;
            this.receipt_url = receipt_url;
            this.instalments = instalments;
            this.quantity = quantity;
            this.unit_price = unit_price;
            this.next_retry_date = next_retry_date;
            this.amount = amount;
            this.event_time = event_time;
            this.subscription_payment_id = subscription_payment_id;
            this.p_signature = p_signature;
            this.gross_refund = gross_refund;
            this.tax_refund = tax_refund;
            this.fee_refund = fee_refund;
            this.earnings_decrease = earnings_decrease;
            this.balance_gross_refund = balance_gross_refund;
            this.balance_tax_refund = balance_tax_refund;
            this.balance_fee_refund = balance_fee_refund;
            this.balance_earnings_decrease = balance_earnings_decrease;
        }
    }
}
