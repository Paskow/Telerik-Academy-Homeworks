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