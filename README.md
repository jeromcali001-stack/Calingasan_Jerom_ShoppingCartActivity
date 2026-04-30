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