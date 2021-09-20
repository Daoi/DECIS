function InitDT(tables) {
    for (let index = 0; index < tables.length; ++index) {

        $(tables[index]).prepend($("<thead></thead>").append($(tables[index]).find("tr:first"))).DataTable({
            lengthMenu: [[5, 10, 25, 50, -1], [5, 10, 25, 50, "All"]],
            dom: 'Bfrtip',
            buttons: [
                'copy', 'csv', 'excel', 'pdf'
            ]
        });
    };
}

