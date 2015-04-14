


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

function ChatMode() {
    var messageId = event.target.getAttribute("id");
    var separatorPos = messageId.lastIndexOf("_");
    var Type = messageId.slice(messageId.indexOf("_")+1, separatorPos);
    var Id = messageId.slice(separatorPos + 1, messageId.length);

    alert(Id);
    window.location.href = "ChatRoom.aspx?Type=" + Type + "&Id=" + Id;


}
