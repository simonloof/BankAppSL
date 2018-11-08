using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimonsBankApp.Bank
{
    public class Account 
    {
        public int AccountNo { get; set; }
        public decimal Balance { get; set; }

        public string WithDrawal(int sum)
        {
            if (sum > Balance)
            {
                return "Det finns inte tillräckligt med tecking på kontot";
            }
            if (sum < 0)
            {
                return "Uttaget kan inte vara negativt";
            }
            if (sum == 0)
            {
                return "Fel format på indata";
            }

            Balance -= sum;
            return "success";
        }

        public string Deposit(int sum)
        {
            if (sum < 0)
            {
                return "Uttaget kan inte vara negativt";
            }
            if (sum == 0)
            {
                return "Fel format på indata";
            }
            Balance += sum;
            return "success";
        }

       

    }
}
