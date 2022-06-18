using System;
using System.Collections.Generic;
using System.Text;

/* ************************************************
 * CIS123: Intro to Object-oriented Programming
 * Murach C#, 7th ed. pp. 456 - 458
 * Chapter 13: How to work with indexers
 *    delegates, events & operators
 * Dominique Tepper, 17JUN2022
 * 
 * Exercise 13-1
 * 5a. Add CustomerList class to the project
 * 5b. declare private var that can store list of 
 *     Customer objects
 *     
 * 6. Add members and methods to the CustomerList cs
 *    a. constructor
 *    b. indexer [index]
 *    c. Count property
 *    d. methods
 *          1. Add(customer)
 *          2. Remove(customer)
 *          3. Fill()
 *          4. Save()
 * ************************************************/

namespace CustomerMaintenance
{ 
	public class CustomerList
	{
		//5b. private list
		private List<Customer> customers;

		//6a. constructor
		public CustomerList()
		{
			customers = new List<Customer>();
		}

		//6c. count property
		public int Count => customers.Count;

		//6b. indexer
		public Customer this[int i]
		{
			get
			{
				return customers[i];
			}
			set
			{
				customers[i] = value;
			}
		}
		//6d-1. Add(customer)
		public void Add(Customer customer)
		{
			customers.Add(customer);
		}

		//6d-2. Remove(customer)
		public void Remove(Customer customer)
		{
			customers.Remove(customer);
		}

		//6d-3. Fill()
		public void Fill() => customers = CustomerDB.GetCustomers();

		//6d-4. Save()
		public void Save() => CustomerDB.SaveCustomers(customers);

	}
}
