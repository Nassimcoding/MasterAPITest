using MasterAPITest.Models;
using MasterAPITest.Repository;
using MasterAPITest.DModel;
using System.Data;

namespace MasterAPITest.DataGenerator
{
    public class ImplementTest
    {
        private readonly ProductDAL _storePageDAL;
        public ImplementTest(ProductDAL storePageDAL)
        {
            _storePageDAL = storePageDAL;
        }
        public async void aaatest()
        {
            //bool a = await _storePageDAL.Insert(new List<IProduct>());

        }

        public async Task<string> ttttt(int dataCount = 1)
        {

            var productGenerator = new ProductDataGenerator();
            List<Product> listofproduct = new List<Product>();
            List<DProduct> datalistofproduct = new List<DProduct>();
            Product product = productGenerator.ProductDataGenerate();
            for (int i = 0; i < dataCount; i++)
            {
                listofproduct.Add(productGenerator.ProductDataGenerate());
            }
            bool checkinsert = await _storePageDAL.Insert(listofproduct);

            listofproduct.OrderBy(sid => sid.ProductID);
            for (int i = 0; i < dataCount; i++)
            {
                datalistofproduct.Add(await _storePageDAL.GetByID(listofproduct[i].ProductID));
            }

            bool t1 = listofproduct.Count == datalistofproduct.Count;
            if (!t1)
            {
                return (" : data數量錯誤");
            }
            bool t2;
            bool t3;
            bool t4;
            for (int i = 0; i < listofproduct.Count; i++)
            {
                t2 = listofproduct[i].ProductID == datalistofproduct[i].ProductID;
                t3 = listofproduct[i].ProductCategoryID == datalistofproduct[i].ProductCategoryID;
                t4 = listofproduct[i].StoreID == datalistofproduct[i].StoreID;
                if (t2 && t3 && t4 == false)
                {
                    return (i + " : data錯誤");
                }
            }

            return ("success");
        }

    }
}
