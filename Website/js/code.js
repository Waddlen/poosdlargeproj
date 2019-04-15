var APIRoot = "./PHP/";
var fileExtension = ".php";
var menuName = "";

/*  add to leaderboard.html: 
        - make small changes to text
        - add a drop-down menu for selecting level
        - add a frame for the leaderboard posts
        - list as #, nickname, score
        - configure frame to print 20/page
    add new code.js:
        - include getPosts() to grab drop down menu selection
        - sent back results as {nickname, score}
        - adjust menuName to reflect name of menu element id
*/

function getPosts() 
{
    var search = document.getElementById(menuName).value;
    
}