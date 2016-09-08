'use strict';

class listNode {
    constructor(element) {
        this._data = element;
        this._nextNode = null;
    }

    get data() {
        return this._data;
    }

    set data(value) {
        this._data = value;
    }

    get nextNode() {
        return this._nextNode;
    }

    set nextNode(value) {
        this._nextNode = value;
    }
}

class LinkedList {
    constructor() {
        this._length = 0;
        this._head = null;
    }

    get first() {
        return this.at(0);
    }

    get last() {
        if (this._length > 0) {
            return this.at(this._length - 1);
        }

        return this.first;
    }

    get length() {
        return this._length;
    }

    append(...items) {
        items = items.map(item => new listNode(item));
        let startIndex = 0;
        if (this._length < 1) {
            startIndex = 1;
            this._head = items[0];
            this._length += 1;
        }

        let lastNode = this._getNodeAtIndex(this._length - 1);
        for (let i = startIndex; i < items.length; i += 1) {
            lastNode.nextNode = items[i];
            lastNode = items[i];
            this._length += 1;
        }

        return this;
    }

    prepend(...items) {
        items = items.map(item => new listNode(item));

        if (items.length === 1) {
            let lasthead = this._head;
            this._head = items[0];
            this._head.nextNode = lasthead;
            this._length += 1;
            return this;
        }

        let lasthead = this._head;
        this._head = items[0]
        let lastNode = this._head;
        this._length += 1;
        for (let i = 1; i < items.length; i += 1) {
            lastNode.nextNode = items[i];
            lastNode = lastNode.nextNode;
            this._length += 1;
        }

        lastNode.nextNode = lasthead;

        return this;
    }

    insert(index, ...items) {
        if (index === 0) {
            this.prepend(...items);
            return this;
        }

        items = items.map(item => new listNode(item));

        let lastNode = this._getNodeAtIndex(index - 1);
        let endNode = this._getNodeAtIndex(index);

        for (let i = 0; i < items.length; i += 1) {
            lastNode.nextNode = items[i];
            lastNode = lastNode.nextNode;
            this._length += 1;
        }

        lastNode.nextNode = endNode;

        return this;

    }

    at(index, value) {
        if (value === undefined) {
            return this._getNodeAtIndex(index).data;
        }

        this._getNodeAtIndex(index).data = value;
    }

    removeAt(index) {
        let nodeToBeRemoved = this._getNodeAtIndex(index);
        if (index === 0) {
            this._head = this._head.nextNode;
            this._length -= 1;
            return nodeToBeRemoved.data;
        } else if (index === this.length - 1) {
            let nodeBeforeLastNode = this._getNodeAtIndex(this.length - 2);
            nodeBeforeLastNode.nextNode = null;
            this._length -= 1;
            return nodeToBeRemoved.data;
        }

        let nodeBefore = this._getNodeAtIndex(index - 1);
        let nodeAfter = this._getNodeAtIndex(index + 1);
        nodeBefore.nextNode = nodeAfter;
        this._length -= 1;
        return nodeToBeRemoved.data;
    }

    toArray() {
        let linkedArray = [];
        for (let item of this) {
            linkedArray.push(item);
        }

        return linkedArray;
    }

    toString() {
            let arr = this.toArray();
            return arr.join(' -> ');
        }
        [Symbol.iterator]() {
            let currentNode = this._head;

            return {
                next: function() {
                    if (currentNode === null) {
                        return { done: true };
                    } else {
                        let data = currentNode.data;
                        currentNode = currentNode.nextNode;
                        return {
                            value: data,
                            done: false
                        }
                    }
                }
            }
        }

    _getNodeAtIndex(index) {
        if (index <= 0) {
            return this._head;
        }
        if (index > this._length - 1) {
            return null;
        }

        let currentNode = this._head;
        let currentIndex = 0;
        while (currentNode !== null && currentIndex < index) {
            currentNode = currentNode.nextNode;
            currentIndex += 1;
        }

        return currentNode;
    }
}

module.exports = LinkedList;