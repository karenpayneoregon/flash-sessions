
/*
 * DO NOT copy-n-paste as there is form specific code here
 */

var $SweetDialogs = $SweetDialogs || {};
$SweetDialogs = function () {
    var ThreeButtonQuestion = function () {
        GetConfirmationThreeButtons();
    };

    var TwoButtonQuestion = function () {
        GetConfirmation();
    };

    function GetConfirmationThreeButtons() {
        (async () => {

            const swalWithBootstrapButtons = Swal.mixin({
                customClass: {
                    confirmButton: 'btn btn-success',
                    denyButton: 'btn btn-primary',
                    cancelButton: 'btn btn-danger'
                },
                buttonsStyling: false
            });

            swalWithBootstrapButtons.fire({
                title: 'Do you want to save the changes?',
                showDenyButton: true,
                showCancelButton: true,
                confirmButtonText: 'Save',
                denyButtonText: `Don't save`,
                allowOutsideClick: false,
            }).then((result) => {
                if (result.isConfirmed) {
                    $("#_confirmation1").val(1);
                    document.getElementById("_resultItem").setAttribute('value', 'Confirmed from three buttons');
                    document.getElementById("form1").submit();
                } else if (result.isDenied) {
                    $("#_confirmation1").val(2);
                    document.getElementById("_resultItem").setAttribute('value', 'do not save from three buttons');
                    document.getElementById("form1").submit();
                } else {
                    $("#_confirmation1").val(3);
                    document.getElementById("_resultItem").setAttribute('value', 'Cancel from three buttons');
                    document.getElementById("form1").submit();
                }
            });
        })();
    };
    /*
     * This can be enhanced by passing in the title and text to display
     */
    function GetConfirmation() {
        (async () => {

            const swalWithBootstrapButtons = Swal.mixin({
                customClass: {
                    confirmButton: 'btn btn-danger',
                    cancelButton: 'btn btn-primary' 
                },
                buttonsStyling: false
            });

            swalWithBootstrapButtons.fire({
                title: 'Are you sure?',
                html: "You <strong>won't</strong> be able to revert this!",
                // Karen is not a fan of the icons
                //icon: 'warning',
                iconHtml: '<img src="wwwroot/images/OEDsmall.png">',
                showCancelButton: true,
                confirmButtonText: 'Yes, delete it!',
                cancelButtonText: 'No, cancel!',
                allowOutsideClick: false,
            }).then((result) => {
                if (result.isConfirmed) {
                    // TODO remove for production, instead perform an action
                    document.getElementById("_resultItem").value = 'Okay';
                } else if (result.isDismissed) {
                    // TODO remove for production, instead perform an action
                    document.getElementById("_resultItem").value = 'No';
                } 
            });
        })();
    };

    /*
     * Variation of above, here title, message text and button text are passed in.
     */
    function Confirmation(title, message, yesText, noText) {
        (async () => {

            const swalWithBootstrapButtons = Swal.mixin({
                customClass: {
                    confirmButton: 'btn btn-primary',
                    cancelButton: 'btn btn-primary'
                },
                buttonsStyling: false
            });

            swalWithBootstrapButtons.fire({
                title: title,
                html: message,
                showCancelButton: true,
                confirmButtonText: yesText,
                cancelButtonText: noText,
                allowOutsideClick: false,
            }).then((result) => {
                if (result.isConfirmed) {
                    // TODO remove for production, instead perform an action
                    document.getElementById("_resultItem").value = 'Yes';
                } else if (result.isDismissed) {
                    // TODO remove for production, instead perform an action
                    document.getElementById("_resultItem").value = 'No';
                }
            });
        })();
    };

    function messageBox(title, message) {
        (async () => {

            Swal.fire({
                title: title,
                html: message,
                //icon: 'info',
                width:'40em',
                confirmButtonText: 'OK',
                confirmButtonColor: "black",
                allowOutsideClick: false,
                footer: '<span style="font-style: italic;font-size: 12px">OED 2024</span>'
            }).then((result) => {
                if (result.isConfirmed) {
                    // do nothing
                }
            });
        })();
    };
    return {
        ThreeButtonQuestion: ThreeButtonQuestion,
        TwoButtonQuestion: TwoButtonQuestion,
        messageBox: messageBox,
        Confirmation: Confirmation
    };
}();