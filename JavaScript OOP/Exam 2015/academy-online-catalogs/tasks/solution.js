function solve() {
    let itemId = 0;
    let catalogId = 0;

    class Item {
        constructor(description, name) {
            this._id = Item._idGenerator();
            if (description.length === 0) {
                throw new Error();
            }
            if (name.length < 2 || name.length > 40) {
                throw new Error()
            }
            this._description = description;
            this._name = name;
        }

        get id() {
            return this._id;
        }

        get name() {
            return this._name;
        }

        get description() {
            return this._description;
        }

        set name(value) {
            if (value.length < 2 || value.length > 40) {
                throw new Error()
            }
            this._name = value;
        }

        set description(value) {
            if (value.length === 0) {
                throw new Error();
            }
            this._description = value;
        }

        static _idGenerator() {
            return itemId += 1;
        }
    }

    class Book extends Item {
        constructor(name, isbn, genre, description) {
            super(description, name);
            if (isNaN(isbn) || (isbn.length !== 10 && isbn.length !== 13)) {
                throw new Error();
            }
            if (genre.length < 2 || genre.length > 20) {
                throw new Error();
            }
            this._isbn = isbn;
            this._genre = genre;
        }

        get isbn() {
            return this._isbn;
        }

        get genre() {
            return this._genre;
        }

        set isbn(value) {
            if (isNaN(value) || (value.length !== 10 && value.length !== 13)) {
                throw new Error();
            }
            this._isbn = value;
        }

        set genre(value) {
            if (value.length < 2 || value.length > 20) {
                throw new Error()
            }
            THIS._genre = value;
        }

    }

    class Media extends Item {
        constructor(name, rating, duration, description) {
            super(description, name);
            if (duration < 1 || isNaN(duration)) {
                throw new Error();
            }
            if (rating < 1 || rating > 5 || isNaN(rating)) {
                throw Error();
            }

            this._rating = rating;
            this._duration = duration;
        }

        get rating() {
            return this._rating;
        }

        get duration() {
            return this._duration;
        }

        set rating(value) {
            if (value < 1 || value > 5 || isNaN(rating)) {
                throw Error();
            }
            this._rating = value;
        }

        set duration(value) {
            if (value < 1 || isNaN(duration)) {
                throw new Error();
            }
            this._duration = value;
        }

    }

    class Catalog {
        constructor(name) {
            if (name.length < 2 || name.length > 40) {
                throw new Error();
            }
            this._name = name;
            this._id = Catalog._idGenerator();
            this._items = [];
        }

        get id() {
            return this._id;
        }

        get name() {
            return this._name;
        }

        set name(value) {
            if (value.length < 2 || value.length > 40) {
                throw new Error();
            }

            this._name = value;
        }

        get items() {
            return this._items;
        }

        set items(value) {
            this._items = value;
        }

        static _idGenerator() {
            return catalogId += 1;
        }

        add(...items) {
            if (items === undefined || items.length === 0) {
                throw new Error();
            }
            items.forEach(function(item) {
                if (!(item instanceof Item)) {
                    throw new Error();
                }
            });
            items.forEach(x => this._items.push(x));
            return this;
        }

        find(parameter) {
            if (!(parameter instanceof Object) && !(typeof parameter === 'number')) {
                throw new Error();
            }

            var result = null;

            if (!isNaN(parameter)) {
                this._items.forEach(function(item) {
                    if (item.id === parameter) {
                        result = item;
                    }
                });
                return result;
            }

            result = [];
            var keys = Object.keys(parameter);
            for (let i = 0; i < this._items.length; i += 1) {
                for (let j = 0; j < keys.length; j += 1) {
                    if (this._items[i][keys[j]] === parameter[keys[j]]) {
                        if (j === keys.length - 1) {
                            result.push(this._items[i]);
                        } else {
                            continue;
                        }
                    }

                    break;
                }
            }

            return result;
        }

        search(pattern) {
            if (pattern.length < 1) {
                throw new Error();
            }
            pattern = pattern.toLocaleLowerCase();
            var result = [];
            this._items.forEach(function(item) {
                if (item.name.toLocaleLowerCase().indexOf(pattern) >= 0 ||
                    item.description.toLocaleLowerCase().indexOf(pattern) >= 0) {
                    result.push(item);
                }
            });

            return result;
        }
    }

    class BookCatalog extends Catalog {
        constructor(name) {
            super(name);
        }

        add(...items) {
            if (items[0] instanceof Array) {
                items = items[0];
            }
            items.forEach(function(item) {
                if (!(item instanceof Book)) {
                    throw new Error();
                }
            });

            super.add(...items)

            return this;
        }

        getGenres() {
            var uniqueGenres = [];
            this._items.forEach(function(item) {
                if (uniqueGenres.indexOf(item.genre.toLocaleLowerCase) < 0) {
                    uniqueGenres.push(item.genre.toLocaleLowerCase());
                }
            });

            return uniqueGenres;
        }
    }

    class MediaCatalog extends Catalog {
        constructor(name) {
            super(name);
        }

        add(...items) {
            if (items[0] instanceof Array) {
                items = items[0];
            }
            items.forEach(function(item) {
                if (!(item instanceof Media)) {
                    throw new Error();
                }
            });

            super.add(...items)

            return this;
        }

        getTop(count) {
            if (isNaN(count) || count < 1) {
                throw new Error();
            }
            var sortedMedias = this._items.slice(0).sort((a, b) => b.rating - a.rating);
            var topMedias = [];
            for (let i = 0; i < count; i += 1) {
                if (sortedMedias.length - 1 < i) {
                    break;
                }
                topMedias.push({ id: sortedMedias[i].id, name: sortedMedias[i].name });
            }

            return topMedias;
        }

        getSortedByDuration() {
            return this._items.slice().sort(function(a, b) {
                var result = b.duration - a.duration
                if (result === 0) {
                    result = a.id - b.id;
                }

                return result;

            });
        }
    }
    return {
        getBook: function(name, isbn, genre, description) {
            return new Book(name, isbn, genre, description);
        },
        getMedia: function(name, rating, duration, description) {
            return new Media(name, rating, duration, description);
        },
        getBookCatalog: function(name) {
            return new BookCatalog(name);
        },
        getMediaCatalog: function(name) {
            return new MediaCatalog(name);
        }
    }

}

module.exports = solve;