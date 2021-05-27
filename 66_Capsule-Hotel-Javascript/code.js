const CAPSULE_COUNT = 100;
let capsules = [];

function Init() {
    for (let i = 0; i < CAPSULE_COUNT; i++) {
        capsules[i] = { 
            status: "Unoccupied"
        };
    }
}

function UpdateCapsuleDisplay()
{
    const capsuleContainer = document.getElementById("capsules");
    let html = "";
    for (let i = 0; i < CAPSULE_COUNT; i++) {
        let status = "Unoccupied";
        let badge = "badge-success";
        if(capsules[i].status != "Unoccupied") 
        {
            status = capsules[i].status;
            badge = "badge-danger";
        }
        html += `<div>
            <span id="capsuleLabel${i + 1}" class="badge badge-pill ${badge}">Capsule #${i + 1}</span>
            &nbsp;<span id="guest${i + 1}">${status}</span>
        </div>`
    }
    capsuleContainer.innerHTML = html;
}

function BookIt()
{
    fullName = document.getElementById('guest').value;
    capsuleNumber = document.getElementById('bookingCapsule').value;
    if(fullName == null || fullName == "")
    {
        DisplayFailureMessage(`Name is required`);
    }
    else if(capsuleNumber == null)
    {
        DisplayFailureMessage(`Capsule # is required`);
    }
    else if(capsuleNumber < 1 || capsuleNumber > CAPSULE_COUNT)
    {
        DisplayFailureMessage(`Capsule #${capsuleNumber} is not valid`);
    }
    else if(capsules[capsuleNumber-1].status == "Unoccupied")
    {
        capsules[capsuleNumber-1].status = fullName;
        UpdateCapsuleDisplay();
        DisplaySuccessMessage(`Guest: ${fullName} booked in capsule #${capsuleNumber}`);
    }
    else
    {
        DisplayFailureMessage(`Capsule #${capsuleNumber} is occupied`);
    }
    return false;
}

function CheckOut()
{
    capsuleNumber = document.getElementById('checkOutCapsule').value;
    if(capsuleNumber == null)
    {
        DisplayFailureMessage(`Capsule # is required`);
    }
    else if(capsuleNumber < 1 || capsuleNumber > CAPSULE_COUNT)
    {
        DisplayFailureMessage(`Capsule #${capsuleNumber} is not valid`);
    }
    else if(capsules[capsuleNumber-1].status == "Unoccupied")
    {
        DisplayFailureMessage(`Capsule #${capsuleNumber} is unoccupied`);
    }
    else
    {
        capsules[capsuleNumber-1].status = "Unoccupied";
        UpdateCapsuleDisplay();
        DisplaySuccessMessage(`Guest: ${fullName} checked out of capsule #${capsuleNumber}`);
    }
    return false;
}

function DisplayFailureMessage(message)
{
    const messageContainer = document.getElementById("messages");
    messageContainer.classList = "";
    messageContainer.classList.add("alert", "alert-danger");
    messageContainer.innerHTML = message;
}

function DisplaySuccessMessage(message)
{
    const messageContainer = document.getElementById("messages");
    messageContainer.classList = "";
    messageContainer.classList.add("alert", "alert-success");
    messageContainer.innerHTML = message;
}

Init();
UpdateCapsuleDisplay();