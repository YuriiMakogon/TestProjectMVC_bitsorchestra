// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



//const getCellValue = (tr, idx) => tr.children[idx].innerText || tr.children[idx].textContent;

//const comparer = (idx, asc) => (a, b) => ((v1, v2) =>
//    v1 !== '' && v2 !== '' && !isNaN(v1) && !isNaN(v2) ? v1 - v2 : v1.toString().localeCompare(v2)
//)(getCellValue(asc ? a : b, idx), getCellValue(asc ? b : a, idx));

//// do the work...
//document.querySelectorAll('th').forEach(th => th.addEventListener('click', (() => {
//    const table = th.closest('table');
//    Array.from(table.querySelectorAll('tr:nth-child(n+2)'))
//        .sort(comparer(Array.from(th.parentNode.children).indexOf(th), this.asc = !this.asc))
//        .forEach(tr => table.appendChild(tr));
//})));


//function myFunction() {
//    // Declare variables
//    var input, filter, table, tr, td, i, txtValue;
//    input = document.getElementById("myInput");
//    filter = input.value.toUpperCase();
//    table = document.getElementById("table");
//    tr = table.getElementsByTagName("tr");

//    // Loop through all table rows, and hide those who don't match the search query
//    for (i = 0; i < tr.length; i++) {
//        td = tr[i].getElementsByTagName("td")[0];
//        if (td) {
//            txtValue = td.textContent || td.innerText;
//            if (txtValue.toUpperCase().indexOf(filter) > -1) {
//                tr[i].style.display = "";
//            } else {
//                tr[i].style.display = "none";
//            }
//        }
//    }
//}
document.addEventListener('DOMContentLoaded', () => {

    const getSort = ({ target }) => {
        const order = (target.dataset.order = -(target.dataset.order || -1));
        const index = [...target.parentNode.cells].indexOf(target);
        const collator = new Intl.Collator(['en', 'ru'], { numeric: true });
        const comparator = (index, order) => (a, b) => order * collator.compare(
            a.children[index].innerHTML,
            b.children[index].innerHTML
        );

        for (const tBody of target.closest('table').tBodies)
            tBody.append(...[...tBody.rows].sort(comparator(index, order)));

        for (const cell of target.parentNode.cells)
            cell.classList.toggle('sorted', cell === target);
    };

    document.querySelectorAll('.table thead').forEach(tableTH => tableTH.addEventListener('click', () => getSort(event)));

});

$(document).ready(function () {
    $("#myInput").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#table tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });
});