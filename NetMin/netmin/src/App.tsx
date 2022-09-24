import React from "react";
import "./App.less";
import { QueryClient, QueryClientProvider, useQueryClient } from "react-query";
import AppLayout from "./layout/Layout";

const queryClient = new QueryClient();

function App() {
  return (
    <QueryClientProvider client={queryClient}>
      <AppLayout />
    </QueryClientProvider>
  );
}

export default App;
