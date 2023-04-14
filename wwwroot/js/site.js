// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
document.getElementById('btnMakePrediction').addEventListener('click', function () {
    CallAPI();
});
// Write your JavaScript code.
async function CallAPI() {
    // create a JSON object
    var json = {
        squarenorthsouth: parseFloat(document.getElementById("squarenorthsouth").value),
        depth: parseFloat(document.getElementById("depth").value),
        squareeastwest: parseFloat(document.getElementById("squareeastwest").value),
        westtohead: parseFloat(document.getElementById("westtohead").value),
        length: parseFloat(document.getElementById("length").value),
        westtofeet: parseFloat(document.getElementById("westtofeet").value),
        southtofeet: parseFloat(document.getElementById("southtofeet").value),
        east_west_E: parseFloat(document.getElementById("east_west_E").value),
        east_west_W: parseFloat(document.getElementById("east_west_W").value),
        adults_be_adults_A: parseFloat(document.getElementById("adults_be_adults_A").value),
        adults_be_adults_C: parseFloat(document.getElementById("adults_be_adults_C").value),
        area_NE: parseFloat(document.getElementById("area_NE").value),
        area_NNW: parseFloat(document.getElementById("area_NNW").value),
        area_NW: parseFloat(document.getElementById("area_NW").value),
        area_SE: parseFloat(document.getElementById("area_SE").value),
        area_SW: parseFloat(document.getElementById("area_SW").value)
    };

    // serialize the JSON object to a string
    var jsonString = JSON.stringify(json);

    try {
        // send the POST request to the URL
        const response = await fetch("https://localhost:44381/api/score", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: jsonString
        });

        // get the response content as a string
        var responseString = await response.text();

        // do something with the response
        console.log(responseString);

        let trimmedString = responseString.substring(19, responseString.length - 2);
        //console.log(trimmedString);

        if (trimmedString == "E") {
            trimmedString = "Prediction:  East"
        }

        if (trimmedString == "W") {
            trimmedString = "Prediction:  West"
        }

        document.getElementById("response").innerHTML = trimmedString
    } catch (error) {
        // handle the exception
        console.error(error);
    }
}