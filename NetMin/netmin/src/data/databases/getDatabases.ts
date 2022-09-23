import httpClient from "../httpClient";
import DatabaseInfo from "./models/DatabaseInfo";
import {useQuery} from "react-query";

export const getDatabases = async () => await httpClient.get<DatabaseInfo[]>('databases');

export const useGetDatabases = () => {
    const {data, ...rest} = useQuery(['databases'], () => getDatabases());
    
    return {
        databases: data?.data ?? [],
        ...rest
    }
}