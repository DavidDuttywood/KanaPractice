$(document).ready(function () {

    let score = parseInt($("#score").text());

    let messageBank = [
        score + " is good, but i KNOW you can do better!",
        "Anything over " + score + " is just showing off!",
        "There is no way you got " + score + " without cheating!",
        "Sugoi!, " + score + " is practically flying!"
    ];

    if (score % 5 == 0 && score !== 0) {
        
        $("#motivationalMessageContent").text(messageBank[Math.floor(Math.random() * 4)]);

        $("#motivationalMessage").fadeIn();
    }
});