import React from "react";
import { useGetDatabases } from "../data/databases/getDatabases";
import { Layout, Menu } from "antd";

const AppLayout: React.FC = () => {
  const { databases } = useGetDatabases();

  return (
    <Layout>
      <Layout.Sider>
        <Menu>
          {databases.map((db) => (
            <Menu.Item>{db.database}</Menu.Item>
          ))}
        </Menu>
      </Layout.Sider>
      <Layout>
        <Layout.Header>
          <h1>NetMin</h1>
        </Layout.Header>
        <Layout.Content>content</Layout.Content>
        <Layout.Footer>foot</Layout.Footer>
      </Layout>
    </Layout>
  );
};

export default AppLayout;
