using Alamer_Reporting2.DBConnection;
using Alamer_Reporting2.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UpdateScale
{
    class Program
    {
        static void Main(string[] args)
        {
            String query = "";
            string store = "RM01";
            if (store == "SP01")
            {
                 query = "SELECT substring(Code.[Barcode No_],0,8) PluNo ,Item.Description ,[Description 2] ,              (CASE                  WHEN [Offer Price Including VAT] is not null and GETDATE() between offerTbl.[Starting Date] and DATEADD(day, 1, offerTbl.[Ending Date])                     THEN CAST([Offer Price Including VAT]  AS DECIMAL(10,2))                  ELSE CAST(SPrice.[Unit Price Including VAT]  AS DECIMAL(10,2))             END) price,CAST(             CASE                  WHEN Code.[Unit of Measure Code] = 'KG'                      THEN '0'                  ELSE '3'             END AS varchar) ScaleType, [Expiry Period],'0','0'FROM [Al Amer Market$Sales Price] SPrice left JOIN [Al Amer Market$Barcodes] Code ON Code.[Item No_] = SPrice.[Item No_] and Code.[Unit of Measure Code] = SPrice.[Unit of Measure Code] left JOIN [Al Amer Market$Item] Item ON SPrice.[Item No_] = Item.[No_] left join (select OfferLine.No_, OfferLine.[Unit of Measure], OfferLine.[Offer Price Including VAT], DATEADD(day, 0, DATEDIFF(day, 0, vp.[Starting Date])) +    DATEADD(day, 0 - DATEDIFF(day, 0, vp.[Starting Time]), vp.[Starting Time]) [Starting Date] , DATEADD(day, 0, DATEDIFF(day, 0, vp.[Ending Date])) +    DATEADD(day, 0 - DATEDIFF(day, 0, vp.[Ending Time]), vp.[Ending Time]) [Ending Date],Offer.Description  from [Al Amer Market$Offer Line]  OfferLine inner join [Al Amer Market$Offer] Offer on (Offer.[Price Group] = 'STORES' or Offer.[Price Group] = 'SUP' or Offer.[Price Group] = 'WSH' or Offer.[Price Group] = 'MARKETS' or Offer.[Price Group] in ('WSHRE','WSHR','WSHE','SHR')) and Offer.No_ = OfferLine.[Offer No_] and Offer.Status = 1 and  OfferLine.Exclude = 0  and Offer.[Validation Period ID] is not null left join [Al Amer Market$Validation Period] vp on vp.ID = Offer.[Validation Period ID]  where  [Starting Date] <=  Convert(Date, GetDate(), 101) and  [Ending Date]  >= DATEADD(day, 1,Convert(Date, GetDate(), 101))) offerTbl on offerTbl.No_ = Item.No_ and offerTbl.[Unit of Measure] = SPrice.[Unit of Measure Code] where  SPrice.[Sales Code] = 'STORES' and Code.[Is Scale Item] = 1 order by [Barcode No_];";

            }
            else if (store == "HYP")
            {
                 query = "SELECT substring(Code.[Barcode No_],0,8) PluNo ,Item.Description ,[Description 2] ,              (CASE                  WHEN [Offer Price Including VAT] is not null and GETDATE() between offerTbl.[Starting Date] and DATEADD(day, 1, offerTbl.[Ending Date])                     THEN CAST([Offer Price Including VAT]  AS DECIMAL(10,2))                  ELSE CAST(SPrice.[Unit Price Including VAT]  AS DECIMAL(10,2))             END) price,CAST(             CASE                  WHEN Code.[Unit of Measure Code] = 'KG'                      THEN '0'                  ELSE '3'             END AS varchar) ScaleType, [Expiry Period],'0','0'FROM [Al Amer Market$Sales Price] SPrice left JOIN [Al Amer Market$Barcodes] Code ON Code.[Item No_] = SPrice.[Item No_] and Code.[Unit of Measure Code] = SPrice.[Unit of Measure Code] left JOIN [Al Amer Market$Item] Item ON SPrice.[Item No_] = Item.[No_] left join (select OfferLine.No_, OfferLine.[Unit of Measure], OfferLine.[Offer Price Including VAT], DATEADD(day, 0, DATEDIFF(day, 0, vp.[Starting Date])) +    DATEADD(day, 0 - DATEDIFF(day, 0, vp.[Starting Time]), vp.[Starting Time]) [Starting Date] , DATEADD(day, 0, DATEDIFF(day, 0, vp.[Ending Date])) +    DATEADD(day, 0 - DATEDIFF(day, 0, vp.[Ending Time]), vp.[Ending Time]) [Ending Date],Offer.Description  from [Al Amer Market$Offer Line]  OfferLine inner join [Al Amer Market$Offer] Offer on (Offer.[Price Group] = 'STORES' or Offer.[Price Group] = 'HYP'or Offer.[Price Group] = 'WSH' or Offer.[Price Group] = 'MARKETS' or Offer.[Price Group] in ('WSHRE','WSHR','WSHE','SHR')) and Offer.No_ = OfferLine.[Offer No_] and Offer.Status = 1 and  OfferLine.Exclude = 0  and Offer.[Validation Period ID] is not null left join [Al Amer Market$Validation Period] vp on vp.ID = Offer.[Validation Period ID]  where  [Starting Date] <=  Convert(Date, GetDate(), 101) and  [Ending Date] >= DATEADD(day, 1,Convert(Date, GetDate(), 101))) offerTbl on offerTbl.No_ = Item.No_ and offerTbl.[Unit of Measure] = SPrice.[Unit of Measure Code] where  SPrice.[Sales Code] = 'STORES' and Code.[Is Scale Item] = 1 order by [Barcode No_];";

            }
            else if (store == "BK")
            {
                query = "SELECT substring(Code.[Barcode No_],0,8) PluNo ,Item.Description ,[Description 2] ,              (CASE                  WHEN [Offer Price Including VAT] is not null and GETDATE() between offerTbl.[Starting Date] and DATEADD(day, 1, offerTbl.[Ending Date])                     THEN CAST([Offer Price Including VAT]  AS DECIMAL(10,2))                  ELSE CAST(SPrice.[Unit Price Including VAT]  AS DECIMAL(10,2))             END) price,CAST(             CASE                  WHEN Code.[Unit of Measure Code] = 'KG'                      THEN '0'                  ELSE '3'             END AS varchar) ScaleType, [Expiry Period],'0','0'FROM [Al Amer Bakery$Sales Price] SPrice left JOIN [Al Amer Bakery$Barcodes] Code ON Code.[Item No_] = SPrice.[Item No_] and Code.[Unit of Measure Code] = SPrice.[Unit of Measure Code] left JOIN [Al Amer Bakery$Item] Item ON SPrice.[Item No_] = Item.[No_] left join (select OfferLine.No_, OfferLine.[Unit of Measure], OfferLine.[Offer Price Including VAT], DATEADD(day, 0, DATEDIFF(day, 0, vp.[Starting Date])) +    DATEADD(day, 0 - DATEDIFF(day, 0, vp.[Starting Time]), vp.[Starting Time]) [Starting Date] , DATEADD(day, 0, DATEDIFF(day, 0, vp.[Ending Date])) +    DATEADD(day, 0 - DATEDIFF(day, 0, vp.[Ending Time]), vp.[Ending Time]) [Ending Date],Offer.Description  from [Al Amer Bakery$Offer Line]  OfferLine inner join [Al Amer Bakery$Offer] Offer on (Offer.[Price Group] = 'STORES' ) and Offer.No_ = OfferLine.[Offer No_] and Offer.Status = 1 and  OfferLine.Exclude = 0  and Offer.[Validation Period ID] is not null left join [Al Amer Bakery$Validation Period] vp on vp.ID = Offer.[Validation Period ID]  where  [Starting Date] <=  Convert(Date, GetDate(), 101) and  [Ending Date] >= DATEADD(day, 1,Convert(Date, GetDate(), 101))) offerTbl on offerTbl.No_ = Item.No_ and offerTbl.[Unit of Measure] = SPrice.[Unit of Measure Code] where  SPrice.[Sales Code] = 'STORES' and Code.[Is Scale Item] = 1 order by [Barcode No_];";

            }
            else if (store == "RM01")
            {
                query = "SELECT substring(Code.[Barcode No_],0,8) PluNo ,Item.Description ,[Description 2] ,              (CASE                  WHEN [Offer Price Including VAT] is not null and GETDATE() between offerTbl.[Starting Date] and DATEADD(day, 1, offerTbl.[Ending Date])                     THEN CAST([Offer Price Including VAT]  AS DECIMAL(10,2))                  ELSE CAST(SPrice.[Unit Price Including VAT]  AS DECIMAL(10,2))             END) price,CAST(             CASE                  WHEN Code.[Unit of Measure Code] = 'KG'                      THEN '0'                  ELSE '3'             END AS varchar) ScaleType, [Expiry Period],'0','0'FROM [Al Amer Market$Sales Price] SPrice left JOIN [Al Amer Market$Barcodes] Code ON Code.[Item No_] = SPrice.[Item No_] and Code.[Unit of Measure Code] = SPrice.[Unit of Measure Code] left JOIN [Al Amer Market$Item] Item ON SPrice.[Item No_] = Item.[No_] left join (select OfferLine.No_, OfferLine.[Unit of Measure], OfferLine.[Offer Price Including VAT], DATEADD(day, 0, DATEDIFF(day, 0, vp.[Starting Date])) +    DATEADD(day, 0 - DATEDIFF(day, 0, vp.[Starting Time]), vp.[Starting Time]) [Starting Date] , DATEADD(day, 0, DATEDIFF(day, 0, vp.[Ending Date])) +    DATEADD(day, 0 - DATEDIFF(day, 0, vp.[Ending Time]), vp.[Ending Time]) [Ending Date],Offer.Description  from [Al Amer Market$Offer Line]  OfferLine inner join [Al Amer Market$Offer] Offer on (Offer.[Price Group] = 'STORES' or Offer.[Price Group] = 'REEF' or Offer.[Price Group] in ('WSHRE','WSHR','SHR')) and Offer.No_ = OfferLine.[Offer No_] and Offer.Status = 1 and  OfferLine.Exclude = 0  and Offer.[Validation Period ID] is not null left join [Al Amer Market$Validation Period] vp on vp.ID = Offer.[Validation Period ID]  where  [Starting Date] <=  Convert(Date, GetDate(), 101) and  [Ending Date] >= DATEADD(day, 1,Convert(Date, GetDate(), 101))) offerTbl on offerTbl.No_ = Item.No_ and offerTbl.[Unit of Measure] = SPrice.[Unit of Measure Code] where  SPrice.[Sales Code] = 'STORES' and Code.[Is Scale Item] = 1 order by [Barcode No_];";

            }

            //   String query = @"SELECT substring(Code.[Barcode No_],0,8) PluNo ,Item.Description ,[Description 2] ,              (CASE                  WHEN [Offer Price Including VAT] is not null and GETDATE() between offerTbl.[Starting Date] and DATEADD(day, 1, offerTbl.[Ending Date])                     THEN CAST([Offer Price Including VAT]  AS DECIMAL(10,2))                  ELSE CAST(SPrice.[Unit Price Including VAT]  AS DECIMAL(10,2))             END) price,CAST(             CASE                  WHEN [Barcode No_] like '730%'                      THEN '3'                  ELSE '0'             END AS varchar) ScaleType, [Expiry Period],'0','0'FROM [Al Amer Market$Sales Price] SPrice left JOIN [Al Amer Market$Barcodes] Code ON Code.[Item No_] = SPrice.[Item No_] and Code.[Unit of Measure Code] = SPrice.[Unit of Measure Code] left JOIN [Al Amer Market$Item] Item ON SPrice.[Item No_] = Item.[No_] left join 

            //(select TOP 1 OfferLine.No_, OfferLine.[Unit of Measure], OfferLine.[Offer Price Including VAT], DATEADD(day, 0, DATEDIFF(day, 0, vp.[Starting Date])) + DATEADD(day, 0 - DATEDIFF(day, 0, vp.[Starting Time]), vp.[Starting Time])[Starting Date], DATEADD(day, 0, DATEDIFF(day, 0, vp.[Ending Date])) + DATEADD(day, 0 - DATEDIFF(day, 0, vp.[Ending Time]), vp.[Ending Time])[Ending Date], Offer.Description  from[Al Amer Market$Offer Line]  OfferLine inner join[Al Amer Market$Offer] Offer on  Offer.No_ = OfferLine.[Offer No_] and Offer.Status = 1 and  OfferLine.Exclude = 0  and Offer.[Validation Period ID] is not null inner join[Al Amer Market$Store Price Group] sg on sg.[Price Group Code] = Offer.[Price Group] left join[Al Amer Market$Validation Period] vp on vp.ID = Offer.[Validation Period ID]  where[Starting Date] <= Convert(Date, GetDate(), 101) and[Ending Date] >= Convert(Date, GetDate(), 101) and sg.Store = '" + store + @"'  order by sg.Priority desc)  offerTbl

            //on offerTbl.No_ = Item.No_ and offerTbl.[Unit of Measure] = SPrice.[Unit of Measure Code] inner join[Al Amer Market$Store Price Group] spg on spg.[Price Group Code] = SPrice.[Sales Code] where spg.Store = '" + store + "' and Code.[Is Scale Item] = 1 order by spg.Priority desc; ";




            Console.WriteLine("Connecting to Alamer Dynamics NAV..." + " "+ AmerSettings.Default.DynamicsServer);
            SqlConnection sqlConnection2 = mdDataConnection.GetSqlConnection(AmerSettings.Default.DynamicsServer, AmerSettings.Default.DynamicsDatabase, AmerSettings.Default.BCUserName, AmerSettings.Default.BCPassword);
            SqlCommand selectCommand = new SqlCommand(query, sqlConnection2);

            if (sqlConnection2.State == ConnectionState.Open)
            {

                Console.WriteLine("Connected, Reading scale items...");
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
                DataTable dataTable2 = new DataTable();
                sqlDataAdapter.Fill(dataTable2);
                StringBuilder sb = new StringBuilder();
                StringBuilder sbBizerba = new StringBuilder();
                int c = 0;
                foreach (DataRow row in dataTable2.Rows)
                {
                    string[] fields = row.ItemArray.Select(field => field.ToString()).
                                                    ToArray();
                    sb.AppendLine(string.Join(",", fields));
                    sbBizerba.AppendLine("0,"+ row.ItemArray[0].ToString().Substring(3,4)+ ",1,1,0000000," + row.ItemArray[3].ToString().Replace(".","")+"," + row.ItemArray[4].ToString().Replace(".", "") + ","+ (row.ItemArray[4].ToString().Replace(".", "").Equals("3") ? "1" : "0") + ",1,"+ row.ItemArray[5].ToString().Replace(".", "") + "," + row.ItemArray[1].ToString()+ ",07"+ (row.ItemArray[4].ToString().Replace(".", "").Equals("3") ? "3" : "2") + "00000000,0000");
                    c++;

                }
                Console.WriteLine("Loaded " + c +" items.");

                try
                {

                    var csvTable = new DataTable();



                    File.WriteAllText("D:\\Amer Scale Data\\fromcloud\\UpdateScale01.Csv", sb.ToString());
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Toledo items updated Successfully! ");
                    Console.ForegroundColor = ConsoleColor.Gray;

                    File.WriteAllText("D:\\Amer Scale Data\\fromcloud\\plst.Csv", sbBizerba.ToString());

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Bizerba items updated Successfully! ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                  //  File.WriteAllText("\\\\172.16.1.45\\Toledo PLU\\log.txt", "Last update: " + DateTime.Now +"\n" + "Item count: " + c);

                   
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Error in sending the update file, the scales failed to update: " + ex.Message);
              
                }
                Console.WriteLine("Tool closing in..");
                for(int i = 5; i > 0; i--)
                {
                    Console.WriteLine(i);
                    System.Threading.Thread.Sleep(1000);
                }
              
                //  Console.ReadKey(true);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Cannot connect to the server.");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Press any key to close...");
                Console.ReadKey(true);
            }
        }
    }
}
