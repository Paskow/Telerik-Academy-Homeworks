/* Task Description */
/* 
 *	Create a module for working with books
 *	The module must provide the following functionalities:
 *	Add a new book to category
 *	Each book has unique title, author and ISBN
 *	It must return the newly created book with assigned ID
 *	If the category is missing, it must be automatically created
 *	List all books
 *	Books are sorted by ID
 *	This can be done by author, by category or all
 *	List all categories
 *	Categories are sorted by ID
 *	Each book/catagory has a unique identifier (ID) that is a number greater than or equal to 1
 *	When adding a book/category, the ID is generated automatically
 *	Add validation everywhere, where possible
 *	Book title and category name must be between 2 and 100 characters, including letters, digits and special characters ('!', ',', '.', etc)
 *	Author is any non-empty string
 *	Unique params are Book title and Book ISBN
 *	Book ISBN is an unique code that contains either 10 or 13 digits
 *	If something is not valid - throw Error
 */
function solve() {
    var library = (function() {
        var books = [];
        var categories = [];

        function listBooks(parameter) {
            if (parameter) {
                if (parameter.hasOwnProperty('category')) {
                    var booksWithThisCategory = [];
                    books.forEach(function(book) {
                        if (book.category === parameter.category) {
                            booksWithThisCategory.push(book);
                        }
                    });
                    return booksWithThisCategory;
                } else if (parameter.hasOwnProperty('author')) {
                    var booksWithThisAuthor = [];
                    books.forEach(function(book) {
                        if (book.author === parameter.author) {
                            booksWithThisAuthor.push(book);
                        }
                    });
                    return booksWithThisAuthor;
                }
            }

            return books.sort(book => book.id);
        }

        function validateBook(book) {
            if (book.title.length < 2 || book.title.length > 100 ||
                book.category.length < 2 || book.category.length > 100 ||
                book.author === "" ||
                isNaN(book.isbn) ||
                book.isbn < 1000000000 ||
                book.isbn > 9999999999999) {
                throw new Error();
            }

            books.forEach(function(firstbook) {
                if (firstbook.isbn === book.isbn || firstbook.title === book.title) {
                    throw new Error();
                }
            });
        }

        function addBook(book) {
            validateBook(book);
            if (categories.indexOf(book.category) < 0) {
                categories.push(book.category);
            }
            book.ID = books.length + 1;
            books.push(book);
            return book;
        }

        function listCategories() {
            return categories;
        }

        return {
            books: {
                list: listBooks,
                add: addBook
            },
            categories: {
                list: listCategories
            }
        };
    }());

    return library;
}

module.exports = solve;