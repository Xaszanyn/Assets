var marks = localStorage.getItem("marks");

//setInterval(check, 1000);

function pointLog(name)
{
    let icons = document.querySelector(".leaflet-marker-pane");
    
    icons.childNodes.forEach(function(icon, i)
    {
        if (name == icon.lastChild.innerHTML)
        {
            console.log(icon);
            //location.replace("URL");
        }
    });
}

document.addEventListener("keydown", function(event) {
    if (event.code == "KeyE")
    {
        let command = prompt().split(' ');

        switch(command[0])
        {
            case "MARK": case "M":
                alert("marked");
                break;
        }
    }
    else if (event.code == "KeyC")
    {
        pointLog(prompt("LOG"))
    }
});