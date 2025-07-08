using MasterAPITest.Models;
using MasterAPITest.Repository;
using MasterAPITest.DModel;
using System.Data;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace MasterAPITest.DataGenerator
{
    public class ImplementTest
    {
        private readonly ProductDAL _productDAL;
        public ImplementTest(ProductDAL productDAL)
        {
            _productDAL = productDAL;
        }
        public async void aaatest()
        {
            //bool a = await _storePageDAL.Insert(new List<IProduct>());

        }

        //insert test
        public async Task<string> ProductDALInsertInteTest(int dataCount = 1)
        {
            var productGenerator = new ProductDataGenerator();
            List<Product> listofproduct = new List<Product>();
            List<DProduct> datalistofproduct = new List<DProduct>();
            //Product product = productGenerator.ProductDataGenerate();
            for (int i = 0; i < dataCount; i++)
            {
                listofproduct.Add(productGenerator.ProductDataGenerate());
            }
            bool checkinsert = await _productDAL.Insert(listofproduct);

            listofproduct.OrderBy(sid => sid.ProductID);
            for (int i = 0; i < dataCount; i++)
            {
                datalistofproduct.Add(await _productDAL.GetByID(listofproduct[i].ProductID));
            }

            if (listofproduct.Count != datalistofproduct.Count)
            {
                return (" : data數量錯誤");
            }


            for (int i = 0; i < listofproduct.Count; i++)
            {
                string correctMessage = "correct";
                //product property compare
                string output = productPropertyCompare(listofproduct[i], datalistofproduct[i], correctMessage);
                if (correctMessage != "correct")
                {
                    return (output + " wrong index : " + i);
                }
            }

            return ("Insert Test Success");
        }

        //getall test
        public async Task<string> ProductDALGetAllInteTest()
        {
            int addnumber = 0;
            var productGenerator = new ProductDataGenerator();
            List<Product> listofproduct = new List<Product>();
            List<DProduct> datalistofproduct = new List<DProduct>();
            List<DProduct> countDatalistofproduct = new List<DProduct>();
            Product product = productGenerator.ProductDataGenerate();

            datalistofproduct = await _productDAL.GetALL();

            listofproduct.Add(productGenerator.ProductDataGenerate());
            bool checkinsert = await _productDAL.Insert(listofproduct);
            datalistofproduct.Add(await _productDAL.GetByID(listofproduct[addnumber].ProductID));

            //product property compare
            string output = productPropertyCompare(listofproduct[addnumber], datalistofproduct[datalistofproduct.Count - 1]);

            countDatalistofproduct = await _productDAL.GetALL();
            if (datalistofproduct.Count != countDatalistofproduct.Count)
            {
                return $"Count mismatch : data {datalistofproduct.Count} , count data {countDatalistofproduct.Count}";
            }

            return ("GetAll test success : " + output);
        }

        //GetBySearchword
        public async Task<string> ProductDALSearchByKeywordInteTest_NoSearchword()
        {
            var productGenerator = new ProductDataGenerator();
            List<Product> ListOfProduct = new List<Product>();
            List<DProduct> dataListOfProduct = new List<DProduct>();
            long targetID;
            string correct = "all property correct!!";
            string output = string.Empty;

            ListOfProduct.Add(productGenerator.ProductDataGenerate());
            targetID = ListOfProduct[0].ProductID;
            bool IsInsertSuccess = await _productDAL.Insert(ListOfProduct);
            if (!IsInsertSuccess)
            {
                return "insert data error";
            }
            dataListOfProduct = await _productDAL.GetBySearchKeyword(targetID.ToString());

            if (dataListOfProduct.Count != ListOfProduct.Count)
            {
                return "search data count are wrong!!";
            }
            output = productPropertyCompare(ListOfProduct[0], dataListOfProduct[0], correct);
            if (output != correct)
            {
                return "search failled " + output;
            }

            return ("SearchKeyword Test Success " + output);
        }

        // test product data search by any searchword
        public async Task<string> ProductDALSearchByKeywordInteTest_AnySearchword(string kw)
        {
            List<DProduct> dataListOfProduct = new List<DProduct>();
            dataListOfProduct = await _productDAL.GetBySearchKeyword(kw);
            string output = JsonSerializer.Serialize(dataListOfProduct);

            return output;
        }


        //Update
        public async Task<string> ProductDALUpdateTest_1DataUpdateByAutoTest()
        {
            // step 0 set value
            var productGenerator = new ProductDataGenerator();
            List<Product> ListOfProduct = new List<Product>();
            List<DProduct> dataListOfProduct = new List<DProduct>();
            long targetID;
            string fvertify = "Insert data vertify ";
            string allVertifyClear = "ALL TEST CLEAR!! ";
            string output;
            // step 1 insert a new data 
            ListOfProduct.Add(productGenerator.ProductDataGenerate());
            targetID = ListOfProduct[0].ProductID;

            bool checkInsert = await _productDAL.Insert(ListOfProduct);
            if (!checkInsert) return "first insert failled";
            // step 2 search by productID 
            dataListOfProduct.Add(await _productDAL.GetByID(targetID));
            // vertify data
            if (fvertify != productPropertyCompare(ListOfProduct[0], dataListOfProduct[0], fvertify))
            {
                return productPropertyCompare(ListOfProduct[0], dataListOfProduct[0], fvertify);
            }
            // step 3 change data
            // set change data
            string cproductname = "productnameischanged";
            string cdesciption = "descriptionischanged";
            decimal cprice = 0453;
            Product cproduct = productGenerator.ProductDataGenerate();

            ListOfProduct[0].ProductName = cproduct.ProductName;
            ListOfProduct[0].Stock = cproduct.Stock;
            ListOfProduct[0].Description = cproduct.Description;
            ListOfProduct[0].Price = cproduct.Price;
            ListOfProduct[0].ModifyTime = cproduct.ModifyTime;
            ListOfProduct[0].Comment = cproduct.Comment;
            ListOfProduct[0].StoreID = cproduct.StoreID;
            ListOfProduct[0].StoreCategoryID = cproduct.StoreCategoryID;
            ListOfProduct[0].Modifier = cproduct.Modifier;
            ListOfProduct[0].ActiveTimeEnd = cproduct.ActiveTimeEnd;
            ListOfProduct[0].ActiveTimeStart = cproduct.ActiveTimeStart;
            ListOfProduct[0].AllowList = cproduct.AllowList;
            ListOfProduct[0].BlockList = cproduct.BlockList;
            ListOfProduct[0].Status = cproduct.Status;

            // insert data
            checkInsert = await _productDAL.UpdateByID(ListOfProduct[0],targetID);
            if (!checkInsert) return "step 3 changed data failled";

            // step 4 vertify that data
            // get changed data 
            dataListOfProduct.Add(await _productDAL.GetByID(targetID));
            // vertify
            if (2 != dataListOfProduct.Count) return "step 4 get by id failled";
            if (dataListOfProduct[0].ProductID != dataListOfProduct[1].ProductID) return $"ProductID mismatch";
            if (dataListOfProduct[0].ProductName == dataListOfProduct[1].ProductName) return $"ProductName notchanged";

            ListOfProduct[0].Stock = cproduct.Stock;
            ListOfProduct[0].Description = cproduct.Description;
            ListOfProduct[0].Price = cproduct.Price;
            ListOfProduct[0].ModifyTime = cproduct.ModifyTime;
            ListOfProduct[0].Comment = cproduct.Comment;
            ListOfProduct[0].StoreCategoryID = cproduct.StoreCategoryID;
            ListOfProduct[0].Modifier = cproduct.Modifier;
            ListOfProduct[0].ActiveTimeEnd = cproduct.ActiveTimeEnd;
            ListOfProduct[0].ActiveTimeStart = cproduct.ActiveTimeStart;
            ListOfProduct[0].AllowList = cproduct.AllowList;
            ListOfProduct[0].BlockList = cproduct.BlockList;
            ListOfProduct[0].Status = cproduct.Status;
            bool checkUpdate = await _productDAL.UpdateByID(ListOfProduct[0], targetID);
            if (!checkUpdate) return "update by id failled";
            dataListOfProduct.Add(await _productDAL.GetByID(targetID));

            if (allVertifyClear != updateProductPropertyCompare(ListOfProduct[0], dataListOfProduct[2], allVertifyClear))
            {
                return "step 4 Final update data failled";
            }
            output = allVertifyClear + JsonSerializer.Serialize(dataListOfProduct[2]);
            return output;
        }

        public async Task<string> ProductDALUpdateTest_1DataUpdateByKeyword(string kw)
        {
            // step 0 set value
            var productGenerator = new ProductDataGenerator();
            List<Product> ListOfProduct = new List<Product>();
            List<DProduct> dataListOfProduct = new List<DProduct>();
            long targetID;
            string fvertify = "Insert data vertify ";
            string allVertifyClear = "ALL TEST CLEAR!! ";
            string output;
            // step 1 insert a new data 
            ListOfProduct.Add(productGenerator.ProductDataGenerate());
            targetID = ListOfProduct[0].ProductID;

            bool checkInsert = await _productDAL.Insert(ListOfProduct);
            if (!checkInsert) return "first insert failled";
            // step 2 search by productID 
            dataListOfProduct.Add(await _productDAL.GetByID(targetID));
            // vertify data
            if (fvertify != productPropertyCompare(ListOfProduct[0], dataListOfProduct[0], fvertify))
            {
                return productPropertyCompare(ListOfProduct[0], dataListOfProduct[0], fvertify);
            }
            // step 3 change data
            // set change data
            string cproductname = "productnameischanged";
            string cdesciption = "descriptionischanged";
            decimal cprice = 0453;
            Product cproduct = productGenerator.ProductDataGenerate();

            ListOfProduct[0].ProductName = cproduct.ProductName;
            ListOfProduct[0].Stock = cproduct.Stock;
            ListOfProduct[0].Description = kw; // change by kw
            ListOfProduct[0].Price = cproduct.Price;
            ListOfProduct[0].ModifyTime = cproduct.ModifyTime;
            ListOfProduct[0].Comment = cproduct.Comment;
            ListOfProduct[0].StoreID = cproduct.StoreID;
            ListOfProduct[0].StoreCategoryID = cproduct.StoreCategoryID;
            ListOfProduct[0].Modifier = cproduct.Modifier;
            ListOfProduct[0].ActiveTimeEnd = cproduct.ActiveTimeEnd;
            ListOfProduct[0].ActiveTimeStart = cproduct.ActiveTimeStart;
            ListOfProduct[0].AllowList = cproduct.AllowList;
            ListOfProduct[0].BlockList = cproduct.BlockList;
            ListOfProduct[0].Status = cproduct.Status;

            // insert data
            checkInsert = await _productDAL.UpdateByID(ListOfProduct[0], targetID);
            if (!checkInsert) return "step 3 changed data failled";

            // step 4 vertify that data
            // get changed data 
            dataListOfProduct.Add(await _productDAL.GetByID(targetID));
            // vertify
            if (2 != dataListOfProduct.Count) return "step 4 get by id failled";
            if (dataListOfProduct[0].ProductID != dataListOfProduct[1].ProductID) return $"ProductID mismatch";
            if (dataListOfProduct[0].ProductName == dataListOfProduct[1].ProductName) return $"ProductName notchanged";

            bool checkUpdate = await _productDAL.UpdateByID(ListOfProduct[0], targetID);
            if (!checkUpdate) return "update by id failled";
            dataListOfProduct.Add(await _productDAL.GetByID(targetID));

            if (allVertifyClear != updateProductPropertyCompare(ListOfProduct[0], dataListOfProduct[2], allVertifyClear))
            {
                return "step 4 Final update data failled";
            }
            output = allVertifyClear + " ID : " + JsonSerializer.Serialize(dataListOfProduct[2].ProductID)
            + " Description : " + JsonSerializer.Serialize(dataListOfProduct[2].Description);
            return output;
        }


        //Delete
        public async Task<string> ProductDALDeleteTest()
        {
            // step 0 set value
            var productGenerator = new ProductDataGenerator();
            List<Product> ListOfProduct = new List<Product>();
            List<DProduct> dataListOfProduct = new List<DProduct>();
            long targetID;
            string allVertifyClear = "ALL TEST CLEAR!! ";

            ListOfProduct.Add(productGenerator.ProductDataGenerate());
            targetID = ListOfProduct[0].ProductID;

            bool checkInsert = await _productDAL.Insert(ListOfProduct);
            if (!checkInsert) return "first insert failled";

            bool checkDelete = await _productDAL.DeleteByID(targetID,1L);
            if (!checkDelete) return "delete failled";

            //compare
            dataListOfProduct.Add(await _productDAL.GetByID(targetID));
            if (dataListOfProduct[0].IsActive) return "error IsActive change failled";
            if (!dataListOfProduct[0].IsDelete) return "error IsDelete change failled";

            return allVertifyClear;

        }



        //private function----------------------------------
        //private product property compare method
        private string productPropertyCompare(Product a, DProduct b, string output = "all property correct!!")
        {
            if (a.ProductID != b.ProductID) return $"ProductID mismatch";
            if (a.Stock != b.Stock) return $"Stock mismatch";
            if (a.Description != b.Description) return $"Description mismatch";
            if (a.LanguageType != b.LanguageType) return $"LanguageType mismatch";
            if (a.Price != b.Price) return $"Price mismatch";
            //if (!Nullable.Equals(a.CreateTime, b.CreateTime)) return "CreateTime mismatch";
            //if (!Nullable.Equals(a.ModifyTime, b.ModifyTime)) return "ModifyTime mismatch";
            //if (a.CreateTime != b.CreateTime) return $"CreateTime mismatch";
            //if (a.ModifyTime != b.ModifyTime) return $"ModifyTime mismatch";
            if (a.IsActive != b.IsActive) return $"IsActive mismatch";
            if (a.IsDelete != b.IsDelete) return $"IsDelete mismatch";
            if (a.Comment != b.Comment) return $"Comment mismatch";
            if (a.ProductCategoryID != b.ProductCategoryID) return $"ProductCategoryID mismatch";
            if (a.Unit != b.Unit) return $"Unit mismatch";
            if (a.IsMedia != b.IsMedia) return $"IsMedia mismatch";
            if (a.Creator != b.Creator) return $"Creator mismatch";
            if (a.Modifier != b.Modifier) return $"Modifier mismatch";
            if (a.IsTax != b.IsTax) return $"IsTax mismatch";
            if (a.Tax != b.Tax) return $"Tax mismatch";
            if (a.PurePrice != b.PurePrice) return $"PurePrice mismatch";
            if (a.StoreID != b.StoreID) return $"StoreID mismatch";
            if (a.ProductSaleTag != b.ProductSaleTag) return $"ProductSaleTag mismatch";
            //if (!Nullable.Equals(a.ActiveTimeStart, b.ActiveTimeStart)) return "ActiveTimeStart mismatch";
            //if (!Nullable.Equals(a.ActiveTimeEnd, b.ActiveTimeEnd)) return "ActiveTimeEnd mismatch";
            //if (a.ActiveTimeStart != b.ActiveTimeStart) return $"ActiveTimeStart mismatch";
            //if (a.ActiveTimeEnd != b.ActiveTimeEnd) return $"ActiveTimeEnd mismatch";
            if (a.Level != b.Level) return $"Level mismatch";
            if (a.AllowList != b.AllowList) return $"AllowList mismatch";
            if (a.BlockList != b.BlockList) return $"BlockList mismatch";
            if (a.Status != b.Status) return $"Status mismatch";

            return (output);
        }

        private string updateProductPropertyCompare(Product a, DProduct b, string output = "all property correct!!")
        {
            if (a.ProductID != b.ProductID) return $"error ProductID mismatch";
            if (a.Description != b.Description) return $"error Description kw notchanged!!";
            if (a.LanguageType != b.LanguageType) return $"LanguageType mismatch";
            //if (a.CreateTime != b.CreateTime) return $"CreateTime mismatch";
            //if (a.ModifyTime != b.ModifyTime) return $"ModifyTime mismatch";
            if (a.Comment != b.Comment) return $"error Comment notchanged";
            if (a.ProductCategoryID != b.ProductCategoryID) return $"error ProductCategoryID notchanged";
            if (a.Creator != b.Creator) return $"Creator mismatch";
            if (a.Modifier != b.Modifier) return $"error Modifier notchanged";
            if (a.PurePrice != b.PurePrice) return $"PurePrice mismatch";
            if (a.ProductSaleTag != b.ProductSaleTag) return $"ProductSaleTag mismatch";
            //if (a.ActiveTimeStart != b.ActiveTimeStart) return $"ActiveTimeStart mismatch";
            //if (a.ActiveTimeEnd != b.ActiveTimeEnd) return $"ActiveTimeEnd mismatch";
            if (a.AllowList != b.AllowList) return $"error AllowList notchanged";
            if (a.BlockList != b.BlockList) return $"error BlockList notchanged";

            return (output);


        }
    }
}
