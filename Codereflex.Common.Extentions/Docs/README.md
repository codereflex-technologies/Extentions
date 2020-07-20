# Extentions

Codereflex.Common.Extentions or simply Extentions provides repeatedly used functionalities  as
extention method. Some of the extention methods are already existing .net framework methods added with the intention of making 
code cleaner or readble.     

## String Extentions

Following are list of string extention methods and their usuage

### IsJson()   

 Validates if given string is valid and well formed json
If string is well formed json returns true else false.



 ```
  // Returns true
  "{\"Name\":\"Tom\"}".IsJson();
 ```

``` 
  // Returns true 
  string  employeejsonstring = "{ \"Name\":\"Tom\"} 
  employeejsonstring.IsJson();
 ```

 ```
  // Returns false
   "".IsJson();
 ```