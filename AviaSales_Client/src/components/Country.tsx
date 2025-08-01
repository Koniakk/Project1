// src/components/News.tsx
import { useState, useEffect } from 'react';
import { 
  type CountryDTO, 
  fetchCountries, 
  createOrUpdateCountries, 
  deleteCountries 
} from '../api/country_service';
import styles from '../styles/Country.module.css';

const Countries = () => {
  const [topics, setTopics] = useState<CountryDTO[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);
  const [selectedIds, setSelectedIds] = useState<number[]>([]);
  const [formData, setFormData] = useState<Omit<CountryDTO, 'id' | 'createdAt' | 'updatedAt'>>({ 
    name: '' 
  });
  const [editingId, setEditingId] = useState<number | null>(null);

  const loadCountries = async () => {
    try {
      setLoading(true);
      const data = await fetchCountries();
      setTopics(data);
      setError(null);
    } catch (err) {
      setError(err instanceof Error ? err.message : 'Failed to load topics');
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    loadCountries();
  }, []);

  const handleInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setFormData({ name: e.target.value });
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    
    const countryToSave: CountryDTO = {
      id: editingId || undefined,
      name: formData.name
    };

    try {
      await createOrUpdateCountries([countryToSave]);
      resetForm();
      await loadCountries();
    } catch (err) {
      setError(err instanceof Error ? err.message : 'Saving failed');
    }
  };

  const handleDelete = async (ids: number[]) => {
    try {
      await deleteCountries(ids);
      setSelectedIds(selectedIds.filter(id => !ids.includes(id)));
      await loadCountries();
    } catch (err) {
      setError(err instanceof Error ? err.message : 'Deletion failed');
    }
  };

  const resetForm = () => {
    setFormData({ name: '' });
    setEditingId(null);
  };

  const setupEdit = (topic: CountryDTO) => {
    if (topic.id === undefined || topic.id === null) return;
    
    setFormData({ name: topic.name || '' });
    setEditingId(topic.id);
  };

  const toggleSelection = (id: number) => {
    setSelectedIds(prev => 
      prev.includes(id) 
        ? prev.filter(item => item !== id) 
        : [...prev, id]
    );
  };

  const formatDate = (dateString?: string | null) => {
    if (!dateString) return 'N/A';
    const date = new Date(dateString);
    return date.toLocaleDateString('ru-RU', {
      year: 'numeric',
      month: 'short',
      day: 'numeric',
      hour: '2-digit',
      minute: '2-digit'
    });
  };

  if (loading) return <div className={styles.loading}>Loading topics...</div>;
  if (error) return <div className={styles.error}>Error: {error}</div>;

  return (
    <div className={styles.container}>
      <h1 className={styles.header}>Topics Management</h1>

      <form onSubmit={handleSubmit} className={styles.form}>
        <div className={styles.formGroup}>
          <label className={styles.formLabel}>Title</label>
          <input
            type="text"
            name="name"
            value={formData.name || ''}
            onChange={handleInputChange}
            className={styles.formInput}
            required
            placeholder="Enter topic title"
          />
        </div>
        
        <div className={styles.buttonGroup}>
          <button 
            type="submit" 
            className={`${styles.btn} ${styles.btnPrimary}`}
          >
            {editingId ? 'Update Topic' : 'Add Topic'}
          </button>
          {editingId && (
            <button 
              type="button" 
              className={`${styles.btn} ${styles.btnSecondary}`}
              onClick={resetForm}
            >
              Cancel
            </button>
          )}
        </div>
      </form>

      <div className={styles.bulkActions}>
        <button
          className={`${styles.btn} ${styles.btnDanger}`}
          disabled={selectedIds.length === 0}
          onClick={() => handleDelete(selectedIds)}
        >
          Delete Selected ({selectedIds.length})
        </button>
      </div>

      <table className={styles.table}>
        <thead>
          <tr className={styles.tableHeader}>
            <th></th>
            <th>ID</th>
            <th>Title</th>
            <th>Created At</th>
            <th>Updated At</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {topics.map(topic => (
            <tr key={topic.id || 'new'} className={styles.tableRow}>
              <td className={styles.tableCell}>
                {topic.id && (
                  <input
                    type="checkbox"
                    className={styles.checkbox}
                    checked={selectedIds.includes(topic.id)}
                    onChange={() => topic.id && toggleSelection(topic.id)}
                  />
                )}
              </td>
              <td className={styles.tableCell}>{topic.id || 'N/A'}</td>
              <td className={styles.tableCell}>{topic.name || 'Untitled'}</td>
              <td className={styles.tableCell}>{formatDate(topic.createdAt)}</td>
              <td className={styles.tableCell}>{formatDate(topic.updatedAt)}</td>
              <td className={`${styles.tableCell} ${styles.actionsCell}`}>
                {topic.id && (
                  <>
                    <button
                      className={`${styles.btn} ${styles.btnSm} ${styles.btnWarning}`}
                      onClick={() => setupEdit(topic)}
                    >
                      Edit
                    </button>
                    <button
                      className={`${styles.btn} ${styles.btnSm} ${styles.btnDanger}`}
                      onClick={() => topic.id && handleDelete([topic.id])}
                    >
                      Delete
                    </button>
                  </>
                )}
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default Countries;