/* globals $ */

/* 

Create a function that takes an id or DOM element and:
  

*/

function solve(){
  return function (selector) {
    // validate input  
    var buttons = document.getElementsByClassName('button'),
        contents = document.getElementsByClassName('content');
    selector = document.getElementById(selector);
   if ((!(selector instanceof HTMLElement) && !(typeof selector === 'string')) || selector === null){
      throw new Error();
    }

    for (var i = 0; i < buttons.length; i += 1) {
      buttons[i].innerHTML = 'hide';
      buttons[i].addEventListener('click', function(e) {
        var clickedButton = e.target,
            counter = [].indexOf.call(selector.children, clickedButton) + 1;
        while (counter < selector.children.length && selector.children[counter].className !== 'button') {
          if (selector.children[counter].className === 'content'){
            var contentToUpdate = selector.children[counter];
            counter++;
            while (counter < selector.children.length) {
              if (selector.children[counter].className === 'button'){
                if (contentToUpdate.style.display === 'none'){
                  contentToUpdate.style.display = '';
                  clickedButton.innerHTML = 'hide';
                }
                else{
                  contentToUpdate.style.display = 'none';
                  clickedButton.innerHTML = 'show';
                }
                break;
              }
            }
            break;
          }
          counter++;
        }           
      });
    }
  };
}

module.exports = solve;