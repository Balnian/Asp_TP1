


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

    if (Type != "r") {
        var tb = document.getElementById("Tb_Message");
        var message = document.getElementById("m_" + Id).innerText;
        tb.innerText = message;
    }
}

function ThreadMode(event) {
    var messageId = event.getAttribute("id");
    var separatorPos = messageId.lastIndexOf("_");
    var Id = messageId.slice(separatorPos + 1, messageId.length);

    alert("ThreadsManager.aspx?Id=" + Id);
    window.location.href = "ThreadsManager.aspx?Id=" + Id;


}

function SelectedThread(event)
{

    var selectedThread = event.innerHTML;
    alert("ChatRoom.aspx?name=" + selectedThread);

    window.location.href = "ChatRoom.aspx? name=" + selectedThread;





}