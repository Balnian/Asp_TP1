
var timer = 0;

function PreLoadImage(e) {
    var imageTarget = document.getElementById("IMG_Avatar");
    var input = event.target;
    if (imageTarget != null) {
        var fReader = new FileReader();
        fReader.readAsDataURL(input.files[0]);
        fReader.onloadend = function (event) {
            // the event.target.result contains the image data 
            imageTarget.src = event.target.result;

        }
    }
    return true;
}

function ChatMode(event) {
    var messageId = event.getAttribute("id");
    var separatorPos = messageId.lastIndexOf("_");
    var Type = messageId.slice(messageId.indexOf("_")+1, separatorPos);
    var Id = messageId.slice(separatorPos + 1, messageId.length);
    

    window.location.href = "ChatRoom.aspx?Type=" + Type + "&Id=" + Id;

    
    
}

function ThreadMode(event) {
    var messageId = event.getAttribute("id");
    var separatorPos = messageId.lastIndexOf("_");
    var Id = messageId.slice(separatorPos + 1, messageId.length);

    
    window.location.href = "ThreadsManager.aspx?Id=" + Id;


}

function SelectedThread(event){

    var selectedThread = event.innerHTML;

    window.location.href = "ChatRoom.aspx?name=" + selectedThread;

}

function showbt(e) {
    var msgid = e.getAttribute("id");
    var separatorPos = msgid.lastIndexOf("_");
    var Id = msgid.slice(separatorPos + 1, msgid.length);
    var head = msgid.slice(0,msgid.indexOf("_")+1)

    document.getElementById(head + "r_" + Id).style.visibility = "visible";
    document.getElementById(head + "e_" + Id).style.visibility = "visible";
}
function hidebt(e) {
    var msgid = e.getAttribute("id");

    var separatorPos = msgid.lastIndexOf("_");
    var Id = msgid.slice(separatorPos + 1, msgid.length);
    var head = msgid.slice(0, msgid.indexOf("_") + 1)

    document.getElementById(head + "r_" + Id).style.visibility = "hidden";
    document.getElementById(head + "e_" + Id).style.visibility = "hidden";
}

//change l'�tat de tous les checkbox de la page
//selon l'�tat du checkbox pour tous le monde
$(document).ready(function () {
    $('#evr1').click(function (event) {  //on click
        if (this.checked) { // check select status
            $('input[type="checkbox"]').each(function () { //loop through each checkbox
                this.checked = true;  //select all checkboxes with class "checkbox1"              
            });
        } else {
            $('input[type="checkbox"]').each(function () { //loop through each checkbox
                this.checked = false; //deselect all checkboxes with class "checkbox1"                      
            });
        }
    });

});


function TimeOut(){
   
    timer++;
    if (timer == 10)
    {

        window.location.href = "Login.aspx";
        alert("Votre Session a expirer");
        timer = 0;
    }


}

//$(document).ready(function () {
//    $('#Chatscroll').animate({
//        scrollTop: 2000//$('#chat-scroll').get(0).scrollHeight
//    }, 2000);
//});
function godown(t) {
    
    var chat_div = document.getElementById('Chatscroll');
    chat_div.scrollTop = chat_div.scrollHeight;
}