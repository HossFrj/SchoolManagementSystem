import axios from "axios";

const baseURL = `https://localhost:7075/api/Student`;

export interface Student {
    id: number;
    ssn: string;
    firstName: string;
    lastName: string;
}

export const studentApi = {
    getStudents: async (): Promise<Student[]> => {
        try {
            const response = await axios.get<Student[]>(`${baseURL}/Get`);
            return response.data;
        } catch (error) {
            throw new Error(`خطا در دریافت دانش‌آموزان: ${error instanceof Error ? error.message : "خطای ناشناخته"}`);
        }
    },

    createStudent: async (student: Omit<Student, "id">): Promise<void> => {
        try {
            await axios.post(`${baseURL}/Create`, student, {
                headers: { "Content-Type": "application/json" },
            });
        } catch (error) {
            throw new Error(`خطا در افزودن دانش‌آموز: ${error instanceof Error ? error.message : "خطای ناشناخته"}`);
        }
    },

    updateStudent: async (student: Student): Promise<void> => {
        try {
            await axios.put(`${baseURL}/Update`, student, {
                headers: { "Content-Type": "application/json" },
            });
        } catch (error) {
            throw new Error(`خطا در به‌روزرسانی دانش‌آموز: ${error instanceof Error ? error.message : "خطای ناشناخته"}`);
        }
    },

    deleteStudent: async (id: number): Promise<void> => {
        try {
            await axios.delete(`${baseURL}/Delete`, {
                data: { id },
                headers: { "Content-Type": "application/json" },
            });
        } catch (error) {
            throw new Error(`خطا در حذف دانش‌آموز: ${error instanceof Error ? error.message : "خطای ناشناخته"}`);
        }
    },
};