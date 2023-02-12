import { Counter } from "./components/Counter";
import { Home } from "./components/Home";
import PeopleTable from "./components/PeopleTable";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/counter',
    element: <Counter />
  },
  {
    path: '/fetch-data',
    element: <PeopleTable />
  }
];

export default AppRoutes;
