# AleyantPrintSolution

#Aleyant – Backend Development Task

Bob works in a printing company and manages the ecommerce storefront. 
The company offers a continually expanding catalog of printed products. 
Managing the large hierarchy of categories for these products is a challenge, as it frequently needs to change depending on constant feedback from Bob’s incredibly annoying manager. 
Bob knows Angular and is ready to write a UI to manage the categories but needs you to write the backend API first.
Bob has agreed to a few basic business rules:

1. Every category name will be unique
2. A category cannot have more than one “parent” category 
3. A category can have multiple “child” categories 
4. The category hierarchy depth will never exceed 10 levels

Bob can POST a JSON structure to create or update a category:
{
"Postcards": "5 inch x 6 inch Postcards",
"Postcards": "6 inch x 7 inch Postcards"
}

In this example, the category named “5 inch x 6 inch Postcards” and “6 inch x 7 inch Postcards” are both
child categories of “Postcards”
In addition to managing categories, Bob needs the API to generate a hierarchy of categories, returned in
a format like this:

{
“Postcards”:
{
“5 inch x 6 inch Postcards”: {},
“6 inch x 7 inch Postcards”:
{
“Business Postcards”: {},
“Fun Postcards”: {}
}
},
“Banners”:
{
“Large Banners”: {}
}
}


Here are the deliverables that Bob has defined:

Web service, written in .net core 5 or 6 (c#) to support Bob’s category manager. Include all
methods Bob needs to properly manage categories.
• You may choose which database to use, but MS SQL is preferred
• Please detail any assumptions you have made about the requirements in a separate document
• Documentation on how to configure the category manager API and database for use on a server
In addition to the above deliverables, consider these optional items:
• Unit tests to cover multiple cases
• The API must be secure, so implement authentication
• Docker compose file to quickly run your solution
Rules:
• You may consult pre-written articles on the internet, but should not copy/paste code
• You may not consult with any people, which includes online or in-person. This must be your
work product.
• Do not spend more than 4 hours on this project.

How We Evaluate:
• Did you comply with all the requirements of the project?
• Is your solution easy to read and understand?
• How well does your solution perform?
• Is your code ready for production (stable and secure)?
