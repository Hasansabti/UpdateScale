using Alamer_Reporting2.Utils;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jardtest2.Utils
{
    class mdPublicVars
    {

        public static string store = "HYP";
        public static string version = "V1.0.11";
        public static string SearchedBarCode = "";
        public static string SearchUnitName = "";
        public static mdPublicVars.UserInformation UserInfo;

  

        public enum ScaleBarCodeType
        {
            WeightCode = 1,
            QuantityCode = 2,
            PriceCode = 3,
        }

        public struct BarCodeStrcutre
        {
            public string BarCodeData;
            public mdPublicVars.ScaleBarCodeType BarCodeType;
            public int UID;
            public Decimal Quantity;
            public Decimal Price;
            public Decimal Wegiht;
            public bool IsValidScale;
        }

        public struct UserInformation
        {
            public int UserID;
            public string UserName;
            public bool IsAdmin;
            public bool IsInvAdmin;
            public bool IsInvSupv;
            public int IsCashier;
            public bool IsHeadCashier;
            internal bool SuperAdmin;
        }

        public struct CreditCardData
        {
            public string CardID;
            public string CardHolder;
            public string ExpDate;
            public mdPublicVars.CreditCardData.CardType CustomerCardType;
            public bool IsValidCard;

            public enum CardType
            {
                Span = 2,
                Visa = 3,
                MasterCard = 4,
            }
        }

        public struct InvoicePaymentxxx
        {
            public Decimal TotalAmount;
            public Decimal Discount;
            public Decimal NetTotal;
            public Decimal Totalpaid;
            public Decimal CashAmount;
            public Decimal Span;
            public Decimal Visa;
            public Decimal MasterCard;
            public Decimal ReturnSlip;
            public Decimal CreditAmount;
            public Decimal Donation;
            public Decimal ReturnAmount;

            public void Clear()
            {
                this.TotalAmount = 0M;
                this.Discount = 0M;
                this.NetTotal = 0M;
                this.Totalpaid = 0M;
                this.CashAmount = 0M;
                this.Span = 0M;
                this.Visa = 0M;
                this.MasterCard = 0M;
                this.ReturnSlip = 0M;
                this.ReturnAmount = 0M;
                this.CreditAmount = 0M;
                this.Donation = 0M;
            }

            public bool IsValid() => Decimal.Compare(this.Totalpaid, this.GetTotalPaid()) == 0;

            public Decimal GetTotalPaid() => Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(this.CashAmount, this.Span), this.Visa), this.MasterCard), this.ReturnSlip), this.CreditAmount);

            public Decimal GetReturnAmount() => Decimal.Subtract(this.NetTotal, this.GetTotalPaid());
        }
    }
}
