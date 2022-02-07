function ShowAlert() {
    Swal.fire({
        title: '<h2 style="font-size: 16px;line-height: 1.6rem;font-weight: bolder;">Er du sikker på at du vil slette din profil?</h2>',
        //icon: 'info',
        html:
            '<div class="radio-container">' +
            '<label for="check">' +
            '<input id="check" type="checkbox" class= "checkbox-round" checked="checked" >' +
            'Tryk for at slette profil' +
            '</label>' +
            '</div>',
        showDenyButton: true,
        showCancelButton: false,
        confirmButtonText: 'Slet',
        confirmButtonColor: '#DC2F34',
        denyButtonText: `Annulere`,
    }).then((result) => {
        if (result.isConfirmed) {
            Swal.fire({
                title: '<p style="font-size: 16px;">Din profil er nu slettet! Tak for at være med os! </p>',
                showDenyButton: true,
                showCancelButton: false,
                showConfirmButton: false,
                //confirmButtonText: 'Annuler',
                denyButtonText: `Fortryd!`,
            })
        }
    })

}
