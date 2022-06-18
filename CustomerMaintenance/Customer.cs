using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

/* ************************************************
 * CIS123: Intro to Object-oriented Programming
 * Murach C#, 7th ed. pp. 456 - 458
 * Chapter 13: How to work with indexers
 *    delegates, events & operators
 * Dominique Tepper, 17JUN2022
 * 
 * Exercise 13-1
 * 2. Add code to the Customer class set
 *    accessors for the (a) First Name,
 *    (b) Last Name, (c) Email properties that
 *    throw an exception if >30 characters.
 * ************************************************/

namespace CustomerMaintenance
{
	public class Customer
	{
		private string firstName;
		private string lastName;
		private string email;

		public Customer()
		{
		}

		public Customer(string firstName, 
			string lastName, string email)
		{
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Email = email;
		}

		//2a. First Name exception on set accessor
		public string FirstName
		{
			get
			{
				return firstName;
			}
			set
			{
				if (value.Length > 30)
				{
					throw new ArgumentException(
						"Maximum length of first " +
                        "name is 30 characters.");
				}
				firstName = value;
			}
		}

		//2b. Last Name exception on set accessor
		//Tepper, 17JUN2022
		public string LastName
		{
			get
			{
				return lastName;
			}
			set
			{
				if (value.Length > 30)
				{
					throw new ArgumentException(
						"Maximum length of last " +
                        "name is 30 characters.");
				}
				lastName = value;
			}
		}

		//2c. Email exception on set accessor
		//Tepper, 17JUN2022
		public string Email
		{
			get
			{
				return email;
			}
			set
			{
				if (value.Length > 30)
				{
					throw new ArgumentException(
						"Maximum length of email " +
                        "address is 30 characters.");
				}
				email = value;
			}
		}

		public string GetDisplayText() => 
			firstName + " " + 
			lastName + ", " + 
			email;
	}
}
