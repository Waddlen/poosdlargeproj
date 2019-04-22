var menuName = "level_id";
var boardName = "scoreList";

/*  add to leaderboard.html: 
        - make small changes to text
        - add a drop-down menu for selecting level
        - add a frame for the leaderboard posts
        - list as #, nickname, score
        - configure frame to print 20/page
    add new code.js:
        - include getPosts() to grab drop down menu selection
        - sent back results as {nickname, score}
        - adjust menuName and boardName to reflect name of element ids
*/

function hideOrShow (elementId, showState)
{
    var vis = "visible";
    var dis = "block";
    if ( !showState)
    {
        vis = "hidden";
        dis = "none";
    }
    document.getElementById(elementId).style.visibility=vis;
    document.getElementById(elementId).style.display=dis;
}

function getPosts() 
{
    var search = document.getElementById(menuName).value;
    var xhr = new XMLHttpRequest();
    xhr.open("POST","../php/GetScores.php",false);
    xhr.setRequestHeader("Content-type","application/json; charset=UTF-8");
    var jsonPayload = '{"Search" : "' + search + '"}';

    try
    {
        xhr.onreadystatechange = function()
        {
            if (this.readyState == 4 && this.status == 200)
            {
                hideOrShow(boardName,true);
                var str = xhr.responseText;
                var jsonObject = JSON.parse(str);
                var table = document.getElementById(boardName);
                table.deleteTHead();
                if (str.includes("No Records Found"))
                {
                    var newScore = table.createTHead();
                    var newScoreInfo = newScore.insertRow(0);
                    newContactInfo.scope = "row";
                    newContactIndo.insertCell(0).outerHTML = '<th scope="col">No matching contacts found</th>';
                }
                for (var i = 0; i < jsonObject.results.length; i++)
                {
                    var jsonObjectTwo = jsonObject.results[i];
                    var error = jsonObjectTwo.error;
                    if (error == "")
                    {
                        var newScore = table.createTHead();
                        var newScoreInfo = newScore.insertRow(0);
                        newScoreInfo.scope = "row";
                        newScoreInfo.value = "1";
                        newScoreInfo.insertCell(0).outerHTML = '<th scope="col">'+(jsonObject.results.length-i)+"</th>";
                        newScoreInfo.insertCell(1).outerHTML = '<th scope="col">'+jsonObjectTwo.Nickname+"</th>";
                        newScoreInfo.insertCell(2).outerHTML = '<th scope="col">'+jsonObjectTwo.Time+"</th>";
                    }
                }
                table.classList.add('table-style');
            }
        };
        xhr.send(jsonPayload);
    }
    catch (err)
    {
        document.getElementById("searchResult").innerHTML = err.message;
        alert("BIG ERROR BRO");
    }
}
