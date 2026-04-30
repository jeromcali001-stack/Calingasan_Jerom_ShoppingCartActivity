# Calingasan_Jerom_ShoppingCartActivity
AI Usage in This Project
had used ai to debugged multiple stuff like errors on duplicating product id
debugged using ai when checking lowstocks default 10
used ai to debug the checkout cart system having problems in storing product items to cart and totalling.
used ai to get the formula needed to get the discount of 10%



part 2 
re wrote the code and uses ai to fix error 
at elif choice 4 stock checking prints out all product id used ai to fix the error so that it only show the written id that the user inputted.
ai prompt used "what is wrong with my stock check"
the ai replied with
            Problem 1 — found is inside the if

            You wrote:

            if (products[i].Id == id)
            {
                bool found = true;
            }
            Why wrong?

            Because found only exists inside that block.

            Outside it, the program forgets it.

            Also, you should not create it there.

            Problem 2 
            Right now:

            if (products[i].IsLowStock())

            is outside:

            if (products[i].Id == id)

            So it checks every product, even wrong IDs.

            That’s incorrect.

I decided to Rewrite my code as a practice and also to address the comments as i continue

I encountered a syntax error i used quantity as a variable instead of the one i made which was qty i simply copied my code and ask the ai where did i went wrong also found out that my if else are wrong as i forgot where to put the conditions are. I used ai to find my mistakes after finishing a block of codes.
today i separated the shoppers menu and the store keeper menu and made sure the updated stock is saved whenever it transition to shopper menu. as for ai usage today i didnt use it that much except when i encountered an error and it just said i putted the wrong else if condition in the wrong code block basically in another if else thats why there was no error in terminal but it wont run.

the structure of my code consist of very repetitive structures 
1st Console.Write - varible - readline - for loop - if else - condition
i noticed that i havent used much ai like before and commits everytime i remember thats why there was too much commits.
4/30/26 i still am missing the product search and category and stock reorder and check out mostly part 2.

I asked the ai how to do search and as i skimmed to its code i realized it just uses .ToLower to search and just used for loop to search and bool to match. the .Contains part was taught by ai so that even if the spelling is incomplete it still can search as long as it matches some letter

I asked ai on how do I make an receipt and it helped me part by part like first add a variable some parts were familiar mostly the datetime as it was also used in our python program except it is much easier 
Had trouble running the receipt asked ai for help and finally got told that i just havent saved my cs file which was the history 

i found a error in validation that when i put letters on price it still accepts it the ai explained that it is an error in validation and that the code just make the value to 0 i used ai to help me validate it properly and used its code which is if (double.TryParse(input, out price) && price > 0) to fix my error.

update i also found out duplicate items
I fixed it it was similar to the price so much ai isnt needed just trial and error and some suggestion from the compiler

I added a bunch of y/n to every if else possible and copied the whole code to see what possible bug or crash i might have missed the ai replied with this 
1. POSSIBLE CRASH: TryParse not validated

You used:

int.TryParse(Console.ReadLine(), out id);
❗ Problem:

If invalid input → id becomes 0 silently

(Not crash, but logic bug)

Better:

if (!int.TryParse(Console.ReadLine(), out id))
{
    Console.WriteLine("Invalid ID");
    continue;
}
2. CHECKOUT “Do you wish to continue?” LOGIC IS WRONG
❌ Your code:
if (Console.ReadLine().ToLower() != "y")
{
    Console.WriteLine("Checkout cancelled.");
    continue;
}
❗ Problem:
continue only affects current loop, not properly exiting checkout flow

so i followed its advise and revised it from what it said.

Note: Sir if your reading this I may haved put some commits for part 2 in main but those commits are the ones I did when i decided to rewrite the whole code for practice for the exam and for me to get a better understanding as i may forgot where i left off.

I decided to run it again for another checking and it found this 
I reviewed your whole program — it’s actually very solid now (you already fixed a lot of the earlier issues). But there are still a few important bugs / missing logic problems you should fix before calling it done.

🚨 1. CRITICAL BUG: CHECKOUT “return” breaks EVERYTHING
❌ Your code:
if (Console.ReadLine().ToLower() != "y")
{
    Console.WriteLine("Checkout cancelled.");
    return;
}
⚠️ Problem:
return; exits the ENTIRE program (Main)
So if user cancels checkout → game over (store closes)
✅ FIX (correct behavior)

Replace with:

if (Console.ReadLine().ToLower() != "y")
{
    Console.WriteLine("Checkout cancelled.");
    break;
}

✔ This only exits the CART MENU, not the whole program

🚨 2. BUG: RECEIPT NUMBER NOT INCREMENTED

You use:

Console.WriteLine("Receipt No: " + receiptNumber.ToString("D4"));
❗ Problem:
You never increment receiptNumber
Every receipt will show same number
✅ FIX (add this AFTER checkout success):
receiptNumber++;

Place it after:

Console.WriteLine("Change: PHP " + change);
🚨 3. CHECKOUT DOES NOT CLEAR CART (missing feature)

After successful payment, you SHOULD reset cart:

❗ Missing:
cartCount = 0;
✅ ADD THIS:
cartCount = 0;

Put it after checkout success.

so i revised my code again based on the ai suggested also addressed the out of stock comment from previous part and updated it to my cart system

have an error with the date time and ai said simply to change the public date to datetime simple fix
manual debugging and checking of validation i discovered that i didnt add the stock option when adding a product it defaults to 100 fixed it