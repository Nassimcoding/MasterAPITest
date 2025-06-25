using MasterAPITest.Models;
using MasterAPITest.Repository;
using MasterAPITest.DModel;
using System.Data;

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
            Product product = productGenerator.ProductDataGenerate();
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
                string output = productPropertyCompare(listofproduct[i], datalistofproduct[i],correctMessage);
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
            int addnumber = 1;
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
        public async Task<string> ProductDALSearchByKeywordInteTest(string kw)
        {

            List<DProduct> dataListOfProduct = new List<DProduct>();
            



            dataListOfProduct = await _productDAL.GetBySearchKeyword(kw);



            return ("SearchKeyword Test Success");
        }


        //Update

        //Delete




        //private function----------------------------------
        //private product property compare method
        private string productPropertyCompare(Product a, DProduct b,string output = "all property correct!!")
        {
            if (a.ProductID != b.ProductID) return $"ProductID mismatch";
            if (a.ProductName != b.ProductName) return $"ProductName mismatch";
            if (a.Stock != b.Stock) return $"Stock mismatch";
            if (a.Description != b.Description) return $"Description mismatch";
            if (a.LanguageType != b.LanguageType) return $"LanguageType mismatch";
            if (a.Price != b.Price) return $"Price mismatch";
            if (a.CreateTime != b.CreateTime) return $"CreateTime mismatch";
            if (a.UpdateTime != b.UpdateTime) return $"ModifyTime mismatch";
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
            if (a.ActiveTimeStart != b.ActiveTimeStart) return $"ActiveTimeStart mismatch";
            if (a.ActiveTimeEnd != b.ActiveTimeEnd) return $"ActiveTimeEnd mismatch";
            if (a.Level != b.Level) return $"Level mismatch";
            if (a.AllowList != b.AllowList) return $"AllowList mismatch";
            if (a.BlockList != b.BlockList) return $"BlockList mismatch";
            if (a.Status != b.Status) return $"Status mismatch";

            return (output);
        }



    }
}
