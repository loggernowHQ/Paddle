﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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
        public PaddleWebhook(HttpRequest req)
        {
            var formItemList = req.Form.ToList();
            var type = this.GetType();
            var properties = type.GetProperties();
            foreach (var formItem in formItemList)
            {
                foreach (var property in properties)
                {
                    if (property.Name == formItem.Key && property.CanWrite)
                    {
                        property.SetValue(this, formItem.Value, null);
                    }
                    else if(property.Name == formItem.Key && !property.CanWrite)
                    {
                        throw new Exception("Unable to set propert present in paddle webhook.Please contact Author or check github repository.");
                    }
                }
            }
        }
    }
}
