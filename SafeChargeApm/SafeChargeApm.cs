using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace SafeChargeApm


{
    class SafeChargeCashier
    {
        private static void Main(string[] args)
        {
            //provided by Nuvei
            string merchant_id = "3832456837996201334";
            //provided by Nuvei
            string merchant_site_id = "184063";
            string time_stamp = DateTime.Now.ToString("yyyy-MM-ddHH:mm:ss");
            string currency = "EUR";
            string merchantLocale = "en_US";
            //[TradeNetworks].[dbo].[Users].[UserId]
            string UserId = "4925623";
            //[TradeNetworks].[Live].[EWalletDepositCommunicationLogs].[EwalletDepositRequestId]
            string merchant_unique_id = DateTime.Now.ToString("HHmmMMddyy");
            string item_name_1 = "Local Payment Solutions Test";
            string item_number_1 = "1";
            double item_amount_1 = 200.00;
            int item_quantity_1 = 1;
            double total_amount = item_amount_1;
            //[TradeNetworks].[dbo].[Users].[UserId]
            string user_token_id = "4925623";
            string first_name = "Tony";
            string last_name = "Stoyanov";
            string email = "integration@tiebreak.solutions";
            string address1 = "11 Te St";
            string city = "Sun City";
            string country = "DE";
            string zip = "1000";
            string phone1 = "359888123456";
            string version = "4.0.0";
            string notify_url = "https://db46a064326442f75c6172ae6772049a.m.pipedream.net";
            string success_url = "https://tnstoyanov.wixsite.com/payment-response/success";
            string error_url = "https://tnstoyanov.wixsite.com/payment-response/failed";
            string pending_url = "https://tnstoyanov.wixsite.com/payment-response/pending";
            string back_url = "https://tnstoyanov.wixsite.com/payment-response/cancel";

            string merchantSecretKey = "puT8KQYqIbbQDHN5cQNAlYyuDedZxRYjA9WmEsKq1wrIPhxQqOx77Ep1uOA7sUde";
            string checksum = ComputeSha256Hash(
                merchantSecretKey
                + merchant_id
                + merchant_site_id
                + time_stamp
                + currency
                + merchantLocale
                + UserId
                + merchant_unique_id
                + item_name_1
                + item_number_1
                + item_amount_1
                + item_quantity_1
                + total_amount
                + user_token_id
                + first_name
                + last_name
                + email
                + city
                + country
                + address1
                + zip
                + phone1
                + version
                + notify_url
                + success_url
                + error_url
                + pending_url
                + back_url
                );

            //Build HTTPS request
           // Console.WriteLine("https://secure.safecharge.com/ppp/purchase.do?"
            Console.WriteLine("https://ppp-test.safecharge.com/ppp/purchase.do?"
                + "merchant_id="
                + merchant_id
                + "&merchant_site_id="
                + merchant_site_id
                + "&time_stamp="
                + time_stamp
                + "&currency="
                + currency
                + "&merchantLocale="
                + merchantLocale
                + "&UserId="
                + UserId
                + "&merchant_unique_id="
                + merchant_unique_id
                + "&item_name_1="
                + item_name_1
                + "&item_number_1="
                + item_number_1
                + "&item_amount_1="
                + item_amount_1
                + "&item_quantity_1="
                + item_quantity_1
                + "&total_amount="
                + total_amount
                + "&user_token_id="
                + user_token_id
                + "&first_name="
                + first_name
                + "&last_name="
                + last_name
                + "&email="
                + email
                + "&city="
                + city
                + "&country="
                + country
                + "&address1="
                + address1
                + "&zip="
                + zip
                + "&phone1="
                + phone1
                + "&version="
                + version
                + "&notify_url="
                + notify_url
                + "&success_url="
                + success_url
                + "&error_url="
                + error_url
                + "&pending_url="
                + pending_url
                + "&back_url="
                + back_url
                + "&checksum="
                + checksum
                );


            Console.ReadLine();

            string ComputeSha256Hash(string rawData)
            {
                // Creates a SHA256   (Works the same way for SHA256)
                using (SHA256 sha256Hash = SHA256.Create())
                {
                    // ComputeHash - returns byte array  
                    byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                    // Converts byte array to a string   
                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        //x2 for lowercase chars, X2 for uppercase chars
                        builder.Append(bytes[i].ToString("x2"));
                    }
                    return builder.ToString();
                }
            }
        }
    }
}