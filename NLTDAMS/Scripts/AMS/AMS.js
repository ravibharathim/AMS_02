function SuccessAlert(message) {
    var successMessage = '<div class="alert alert-success alert-dismissible fade in"><a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a><i class="fa fa-check"></i> ' + message + '</div>';
    $('#alert-message').empty().append(successMessage);
}
function InformationAlert(message) {
    var infoMessage = '<div class="alert alert-info alert-dismissible fade in"><a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a><i class="fa fa-info"></i> ' + message + '</div>';
    $('#alert-message').empty().append(infoMessage);
}
function WarningAlert(message) {
    var warningMessage = '<div class="alert alert-warning alert-dismissible fade in"><a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a><i class="fa fa-warning"></i> ' + message + '</div>';
    $('#alert-message').empty().append(warningMessage);
}
function DangerAlert(message) {
    var dangerMessage = '<div class="alert alert-danger alert-dismissible fade in"><a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a><i class="fa fa-ban"></i> ' + message + '</div>';
    $('#alert-message').empty().append(dangerMessage);
}

function DisplayMessage(messageType, message) {
    if (messageType == '0') {
        SuccessAlert(message);
    }
    else if (messageType == '1') {
        InformationAlert(message);
    }
    else if (messageType == '2') {
        WarningAlert(message);
    }
    else if (messageType == '3') {
        DangerAlert(message);
    }
}
