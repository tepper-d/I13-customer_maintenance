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
 *          
 * Exercise 13-2
 * 2. Add overloaded CustomerList class
 *	  a.	+		adds customers
 *	  b.	-		removes customers
 *	  
 * Exercise 13-3
 * 2. Add ChangeHandler delegate to CustomerList
 *    class.
 *    a. method with void return type
 *    b. CustomerList parameter
 * 
 * 3. Add Changed event to CustomerList class.
 *    a. use ChangeHandler delegate
 *    b. raised when customer list is changed
 * ************************************************/

namespace CustomerMaintenance
{ 
	public class CustomerList
	{
		//5b. private list
		private List<Customer> customers;


		//Ex13-3.2a,b. delegate void return type
		//Tepper, 17JUN2022
		public delegate void ChangeHandler
			(CustomerList customers);
		public event ChangeHandler Changed;

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

				//Ex13-3.3b
				//Tepper, 17JUN2022
				Changed(this);
			}
		}
		//6d-1. Add(customer)
		public void Add(Customer customer)
		{
			customers.Add(customer);

			//Ex13-3.3a,b
			//Tepper, 17JUN2022
			Changed(this);

		}

		//6d-2. Remove(customer)
		public void Remove(Customer customer)
		{
			customers.Remove(customer);

			//Ex13-3.3a,b
			//Tepper, 17JUN2022
			Changed(this);
		}

		//6d-3. Fill()
		public void Fill() => customers = CustomerDB.GetCustomers();

		//6d-4. Save()
		public void Save() => CustomerDB.SaveCustomers(customers);

/* ************************************************
* CIS123: Intro to Object-oriented Programming
* Murach C#, 7th ed. pp. 456 - 458
* Chapter 13: How to work with indexers
*    delegates, events & operators
* Dominique Tepper, 17JUN2022
*          
* Exercise 13-2
* 2. Add overloaded CustomerList class
*	  a.	+		adds customers
*	  b.	-		removes customers
* ************************************************/

		//13-2.2a. + operator
		//Tepper, 17JUN2022
		public static CustomerList operator +(CustomerList c1, Customer c)
		{
			c1.Add(c);
			return c1;
		}

		//13-2.2b. - operator
		//Tepper, 17JUN2022
		public static CustomerList operator -(CustomerList c1, Customer c)
		{
			c1.Remove(c);
			return c1;
		}
	}
}
