/***************************************************************************************
* Steps for solution                                                                   *
*    1) Convert string to arry of words by splitting on space.                         *
*    2) Loop thru each word in the array and convert first letter to uppercase         *
*       using the charAt(0) value and then appending the remainder of the word         *
*       using the slice() function                                                     *
*    3) Convert array to string with join() function.                                  *
*                                                                                      *
***************************************************************************************/

function LetterCapitalize(str) { 

  var arr = str.split(" ");
  for (var i = 0; i < arr.length; i++) {
    arr[i] = arr[i].charAt(0).toUpperCase() + arr[i].slice(1);
  }
  
  return arr.join(" ");        
}
