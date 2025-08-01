// src/api/topic.ts
export interface CountryDTO {
  id?: number | null;
  name?: string | null;
  createdAt?: string | null;
  updatedAt?: string | null;
}

export const fetchCountries = async (): Promise<CountryDTO[]> => {
  const response = await fetch(`/avia_sales/country`, { method: "GET" });
  if (!response.ok) {
    const errorData = await response.json();
    throw new Error(errorData.message || 'Failed to fetch countries');
  }
  return response.json();
};

export const createOrUpdateCountries = async (countries: CountryDTO[]): Promise<boolean> => {
  const response = await fetch('/avia_sales/country', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(countries)
  });

  if (!response.ok) {
    const errorData = await response.json();
    throw new Error(errorData.message || 'Failed to save countries');
  }
  
  return true;
};

export const deleteCountries = async (ids: number[]): Promise<boolean> => {
  const response = await fetch('/avia_sales/country', {
    method: 'DELETE',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(ids)
  });

  if (!response.ok) {
    const errorData = await response.json();
    throw new Error(errorData.message || 'Failed to delete countries');
  }
  
  return true;
};