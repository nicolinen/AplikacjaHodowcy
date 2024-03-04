// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function UzupelnijMioty(listaLiniaCtrl, listaMiotId) {
    var listaMioty = $("#" + listaMiotId);
    listaMioty.empty();

    listaMioty.append($('<option/>',
        {
            value: null,
            text: "Wybierz Miot"
        }));

    var wybranaLinia = listaLiniaCtrl.options[listaLiniaCtrl.selectedIndex].value;

    if (wybranaLinia != null && wybranaLinia != '') {
        $.getJSON('/Szczeniak/GetMiotyWgLinii', { liniaId: wybranaLinia }, function (mioty) //ajax request do szczeniakController
        {
            if (mioty != null && !jQuery.isEmptyObject(mioty)) {
                $.each(mioty, function (index, miot) {
                    listaMioty.append($('<option/>',
                        {
                            value: miot.value,
                            text: miot.text
                        }));
                });
            };
        });
    }
    return;
}

function updatePhotoPath(input) {
    var photoPathInput = document.getElementById('photoPath');
    photoPathInput.value = input.value.split(/(\\|\/)/g).pop(); // Pobiera nazwę pliku po ostatnim znaku \ lub / -> regex
}

$('#typeSelect').change(function () {
    var type = $(this).val();
    $('#additionalFields').empty();
    if (type === 'Krajowy') {
        $('#additionalFields').append('<div class="form-group"><label>Krajowe Regulacje:</label><input type="text" class="form-control" name="KrajoweRegulacje" /><span class="text-danger"></span></div>');
    } else if (type === 'Miedzynarodowy') {
        $('#additionalFields').append('<div class="form-group"><label>Kraj:</label><input type="text" class="form-control" name="Kraj" /><span class="text-danger"></span></div>');
    }
});

$(".custom-file-input").on("change", function () {
    var fileName = $(this).val().split("\\").pop();
    document.getElementById('PreviewPhoto').src = window.URL.createObjectURL(this.files[0]);
    document.getElementById('PhotoUrl').value = fileName;
});

function ShowCreateModalForm() {
    $("#DivCreateDialogHolder").modal('show');
    return;
}

function submitModalForm() {
    var btnSubmit = document.getElementById('btnSubmit');
    btnSubmit.click();
}

function refreshLiniaList() {
    var btnBack = document.getElementById('dupBackBtn');
    btnBack.click();
    FillLinie("linie");
}

function FillLinie(linie) {
    var listaLinie = $("#" + linie);
    listaLinie.empty();

    listaLinie.append($('<option>',
        {
            value: null,
            text: "Wybierz linię"
        }));

    $.getJSON("/linia/GetLinie", function (linie) {
        if (linie != null && !jQuery.isEmptyObject(linie)) {
            $.each(linie, function (index, linia) {
                listaLinie.append($('<option/>',
                    {
                        value: linia.value,
                        text: linia.text
                    }));
            });
        };
    });
    return;
}
