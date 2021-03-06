﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Acme.Biz.Tests
{
    [TestClass()]
    public class VendorRepositoryTests
    {
        [TestMethod()]
        public void RetrieveValueTest()
        {
            // Arrange
            var repository = new VendorRepository();
            var expected = 42;

            // Act
            var actual = repository.RetrieveValue<int>("Select ...", 42);

            //Asset
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RetrieveValueStringTest()
        {
            // Arrange
            var repository = new VendorRepository();
            var expected = "test";

            // Act
            var actual = repository.RetrieveValue<string>("Select ...", "test");

            //Asset
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RetrieveValueObjectTest()
        {
            // Arrange
            var repository = new VendorRepository();
            var vendor = new Vendor();
            var expected = vendor;

            // Act
            var actual = repository.RetrieveValue<Vendor>("Select ...", vendor);

            //Asset
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RetrieveTest()
        {
            // Arrange
            var repository = new VendorRepository();
            var expected = new List<Vendor>();
            expected.Add(new Vendor()
            { VendorId = 1, CompanyName = "ABC Corp", Email = "abc@abc.com" });
            expected.Add(new Vendor()
            { VendorId = 2, CompanyName = "XYZ Inc", Email = "xyz@xyz.com" });


            // Act
            var actual = repository.Retrieve();

            // Assert
            CollectionAssert.AreEqual(expected, actual.ToList());

        }

        [TestMethod()]
        public void RetrieveWithIteratorTest()
        {
            // Arrange
            var repository = new VendorRepository();
            var expected = new List<Vendor>()
            {
                {new Vendor() {VendorId = 1, CompanyName="ABC Corp", Email="abc@abc.com"} },
                { new Vendor() { VendorId = 2, CompanyName = "XYZ Inc", Email = "xyz@xyz.com" } }

            };

            // Act
            var vendorIterator = repository.RetrieveWithIterator();
            foreach (var item in vendorIterator)
            {
                Console.WriteLine(item);
            }
            var actual = vendorIterator.ToList();

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RetrieveAllTest()
        {
            // Arrange
            var repository = new VendorRepository();
            var expected = new List<Vendor>()
            {
                 {new Vendor() { VendorId = 22, CompanyName = "Amalgamated Toys", Email = "support@amalgamated.com" } },
                 {new Vendor() { VendorId = 35, CompanyName = "Car Toys", Email = "cars@toys.com" } },
                 { new Vendor() { VendorId = 28, CompanyName = "Toy Blocks Inc", Email = "blocks@toyblocks.com" } },
                 {new Vendor() { VendorId = 42, CompanyName = "Toys for Fun", Email = "contact@toysforfun.com" } }

            };

            // Act
            var vendors = repository.RetrieveAll();

            //var vendorQuery = from v in vendors
            //                  where v.CompanyName.Contains("Toy")
            //                  orderby v.CompanyName
            //                  select v;

            //var vendorQuery = vendors.Where(FilterCompanies)
            //                           .OrderBy(OrderCompaniesByName);

            var vendorQuery = vendors.Where(v => v.CompanyName.Contains("Toy"))
                                     .OrderBy(v => v.CompanyName);

            // Assert
            CollectionAssert.AreEqual(expected, vendorQuery.ToList());
        }

        // Linq functions
        // Where Extension
        //private bool FilterCompanies(Vendor v) => v.CompanyName.Contains("Toy");
        // Order Extension
        //private string OrderCompaniesByName(Vendor v) =>  v.CompanyName;
       

    }
}