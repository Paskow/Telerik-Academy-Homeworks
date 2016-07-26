
module.exports = function solve() {
  return function (element, contents) {
     var isHTMLElement = element instanceof HTMLElement;
     var isString = typeof element === 'string';

     if (!isHTMLElement && !isString){
       throw new Error();
     }

     contents.forEach(function (content){
       if (!(content instanceof HTMLElement) && !((typeof content === 'string' || typeof content === 'number'))){
         throw new Error();
       }
     });

     if (isHTMLElement || isString){
     
       if (!isHTMLElement && isString){
         element = document.getElementById(element);
         if (element === null){
           throw new Error();
         }
         else{
           element.innerHTML = '';
           for (var i = 0; i < contents.length; i += 1) {
              var elementToAdd = document.createElement('div');
              elementToAdd.innerHTML = contents[i];
              element.appendChild(elementToAdd);
           }
         }

       }
       else if (isHTMLElement && !isString)
       {
         element.innerHTML = '';
           for (var j = 0; j < contents.length; j += 1) {
              var elementToAdd = document.createElement('div');
              elementToAdd.innerHTML = contents[j];
              element.appendChild(elementToAdd);
           }
       }
       else{
         throw new Error();
       }
     }
     else{
       throw new Error();
     }
  };
};