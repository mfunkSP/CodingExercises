/*
// RESOURCES: http://youmightnotneedjquery.com/

1. Fix the initial error(s) and explain why it's broken?
2. Fix the list so that it displays properly and explain the changes you made. The proper display should be:
        i = 0
            j = 0    j = 1    j = 2
        i = 1
            j = 0    j = 1    j = 2
        i = 2
            j = 0    j = 1    j = 2
3. Add a button to the html that calls a function. This function will toggle the order of the elements in the list. Initially the list is (i = 0, i = 1, i = 2 and within each i there is a j with the same values). When this button is clicked the order will reverse. If clicked again it will reverse again. This function should replace the entire innerHTML of the list to keep it simple.

*/

(function(undefined) {

    var SPListElement = document.getElementById("SPList");
    
    function setSPListHtml(htmlStr) {
        SPListElement.innerHTML = htmlStr;
    }
    
    function buildNestedList(i, j) {
        var htmlStr = "";
        
        for(; i < 3; i++) {
            htmlStr += "<li>";
            htmlStr += "<div class='i'>i = " + i + "</div>";
            htmlStr += "<div class='j'>";

            for(; j < 3; j++) {
                htmlStr += "<span class='j'>j = " + j + "</span>";
            }
            
            htmlStr += "</div>";
            htmlStr += "</li>";
        }
        
        return htmlStr;
    }
}());

setSPListHtml(buildNestedList(0, 0));