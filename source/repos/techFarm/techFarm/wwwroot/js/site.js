// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function aplicarMascaraCNPJ(event) {
    let cnpj = event.target.value.replace(/\D/g, ""); // Remove todos os caracteres que não são dígitos
    
    if (cnpj.length > 14) cnpj = cnpj.slice(0, 14); // Limita o número de dígitos a 14

    // Aplica a máscara de CNPJ
    if (cnpj.length > 12) {
        cnpj = cnpj.replace(/^(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})$/, "$1.$2.$3/$4-$5");
    } else if (cnpj.length > 8) {
        cnpj = cnpj.replace(/^(\d{2})(\d{3})(\d{3})(\d{0,4})$/, "$1.$2.$3/$4");
    } else if (cnpj.length > 5) {
        cnpj = cnpj.replace(/^(\d{2})(\d{3})(\d{0,3})$/, "$1.$2.$3");
    } else if (cnpj.length > 2) {
        cnpj = cnpj.replace(/^(\d{2})(\d{0,3})$/, "$1.$2");
    }

    event.target.value = cnpj; // Atualiza o campo com a máscara aplicada
}

document.getElementById("CNPJ").addEventListener("input", aplicarMascaraCNPJ);
