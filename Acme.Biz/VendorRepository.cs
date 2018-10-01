using System;
using System.Collections.Generic;

namespace Acme.Biz
{
    public class VendorRepository
    {

        private List<Vendor> vendors;
        /// <summary>
        /// Retrieve one vendor.
        /// </summary>
        /// <param name="vendorId">Id of the vendor to retrieve.</param>
        public Vendor Retrieve(int vendorId)
        {
            // Create the instance of the Vendor class
            Vendor vendor = new Vendor();

            // Code that retrieves the defined customer

            // Temporary hard coded values to return 
            if (vendorId == 1)
            {
                vendor.VendorId = 1;
                vendor.CompanyName = "ABC Corp";
                vendor.Email = "abc@abc.com";
            }
            return vendor;
        }
         
        public IEnumerable<Vendor> Retrieve()
        {
            if(vendors == null)
            {
                vendors = new List<Vendor>();

                vendors.Add(new Vendor() { VendorId = 1, CompanyName = "ABC Corp", Email = "abc@abc.com" });
                vendors.Add(new Vendor() { VendorId = 2, CompanyName = "XYZ Inc", Email = "xyz@xyz.com" });

            }

            for (int i = 0; i < vendors.Count; i++)
            {
                Console.WriteLine(vendors[i]);
            }

            foreach (var vendor in vendors)
            {
                //Console.WriteLine(vendor);
            }



            return vendors;

        }

        public IEnumerable<Vendor> RetrieveAll()
        {
            var vendors = new List<Vendor>()
            {
                {new Vendor() { VendorId = 1, CompanyName = "ABC Corp", Email = "abc@abc.com" } },
                {new Vendor() { VendorId = 2, CompanyName = "XYZ Inc", Email = "xyz@xyz.com" } },
                {new Vendor() { VendorId = 12, CompanyName = "EFG Ltd", Email = "efg@efg.com" } },
                {new Vendor() { VendorId = 17, CompanyName = "HIJ AG", Email = "hij@hij.com" } },
                {new Vendor() { VendorId = 22, CompanyName = "Amalgamated Toys", Email = "support@amalgamated.com" } },
                {new Vendor() { VendorId = 28, CompanyName = "Toy Blocks Inc", Email = "blocks@toyblocks.com" } },
                {new Vendor() { VendorId = 31, CompanyName = "Home Products Inc", Email = "admin@hp.com" } },
                {new Vendor() { VendorId = 35, CompanyName = "Car Toys", Email = "cars@toys.com" } },
                {new Vendor() { VendorId = 42, CompanyName = "Toys for Fun", Email = "contact@toysforfun.com" } },
                {new Vendor() { VendorId = 59, CompanyName = "newmanuevers", Email = "admin@newmanuevers.com" } },

            };

            return vendors;
        }

       

        public T RetrieveValue<T>(string sql, T defaultvalue)
        {
            // Call the database to retrieve the values
            // If no value is returned, return the default value
            T value = defaultvalue;

            return value;
        }

        

        /// <summary>
        /// Save data for one vendor.
        /// </summary>
        /// <param name="vendor">Instance of the vendor to save.</param>
        /// <returns></returns>
        public bool Save(Vendor vendor)
        {
            var success = true;

            // Code that saves the vendor

            return success;
        }

        public IEnumerable<Vendor> RetrieveWithIterator()
        {
            // Get the data from the database
            this.Retrieve();

            foreach (var vendor in vendors)
            {
                Console.WriteLine("Vendor Id: {0}", vendor.VendorId);

                yield return vendor;
            }
        }
    }
}
