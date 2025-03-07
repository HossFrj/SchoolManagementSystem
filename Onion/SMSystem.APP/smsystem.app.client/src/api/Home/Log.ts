import axios from "axios";

const baseURL = `https://localhost:7075/api/OutBoxEventItem`;

export interface Log {
    outBoxEventItemId: number;
    accuredOn: React.ReactNode;
    aggregateName: string;
    eventName: string;
}

export const logApi = {
    getLogs: async (): Promise<Log[]> => {
        try {
            const response = await axios.get<Log[]>(`${baseURL}/Get`);
            return response.data;
        } catch (error) {
            throw new Error(`خطا در دریافت لاگ ها: ${error instanceof Error ? error.message : 'خطای ناشناخته'}`);
        }
    },
};