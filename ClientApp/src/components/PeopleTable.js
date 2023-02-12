import React, { useMemo, useState } from 'react';
import MaterialReactTable from 'material-react-table';

const PeopleTable = () => {
    const [data, setData] = useState([]);

    React.useEffect(() => {
        const populatePeopleData = async () => {
            const response = await fetch('person');
            const data = await response.json();
            setData(data);
        }
        populatePeopleData();
    }, []);

    const columns = useMemo(
        () =>
        [
            {
                accessorKey: 'id',
                enableColumnFilter: false,
                header: 'ID',
            },
            {
                accessorKey: 'name',
                header: 'Name',
                filterVariant: 'text',
            },
            {
                accessorKey: 'dateOfBirth',
                header: 'DateOfBirth',
            },
            {
                accessorKey: 'category',
                enableColumnFilter: false,
                header: 'Category',
            },
        ],
        [],
    );

    return (
        <MaterialReactTable
            columns={columns}
            data={data}
            initialState={{ showColumnFilters: true }}
        />
    );
};

export default PeopleTable;