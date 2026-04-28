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
