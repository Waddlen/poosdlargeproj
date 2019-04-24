# Website
SSH info in the Discord #web-people

View the website live at http://3.89.35.102 - tries to update every 10 seconds, barring some `git push --force` disaster


# API EXAMPLES
The .PHP files take JSON input. I'm going to denote variables as $VAR. Here are some examples of using curl to pass JSON to the site:

## TEST: SUBMIT SCORE TO LEADERBOARD

INPUT: device_id, level_id, time, score (optional)

DESTINATION: http://3.89.35.102/php/AddScore.php

OUTPUT:

- IF VALID: {"error":"", "time":"$GARBAGE"}

- IF INVALID: {"error":"$ERROR_MESSAGE"}
```
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"device_id":"196","level_id":"1","time":"5.6","score":"100"}' \
  http://3.89.35.102/php/AddScore.php
  ```

## TEST: ADD OR UPDATE NICKNAME

INPUT: device_id, nickname

DESTINATION: http://3.89.35.102/php/SetNickname.php

OUTPUT:

- IF VALID: {"error":"", "nickname":"$NICKNAME"}

- IF INVALID: {"error":"$ERROR_MESSAGE"}
```
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"device_id":"143","nickname":"tester"}' \
  http://3.89.35.102/php/SetNickname.php
  ```
  
  ## TEST: GET LEVEL SCORES

INPUT: Search

DESTINATION: http://3.89.35.102/php/GetScores.php

OUTPUT:

- IF VALID: {"results":[{"Nickname":"Jojo","Time":"24.12","error":""},{"Nickname":"Pro Gamer","Time":"25.92","error":""},{"Nickname":"Not As Pro Gamer","Time":"26.1","error":""},{"Nickname":"testingM1","Time":"47.78","error":""}],"error":""}

- IF INVALID: {"level_id":"$level_id","device_id":"$device_id","error":"$ERROR_MESSAGE"}
```
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"Search":"3"}' \
  http://3.89.35.102/php/GetScores.php
```
